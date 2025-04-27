namespace UserService.API.Middelware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExeptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeptionHandlingMiddleware> _logger;

        public ExeptionHandlingMiddleware(RequestDelegate next, ILogger<ExeptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.GetType().ToString()} : {ex.Message}");
                if (ex.InnerException != null)
                {
                    _logger.LogError($"{ex.InnerException.GetType().ToString()} : {ex.InnerException.Message}");
                }
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString() });
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExeptionHandlingMiddleware>();
        }
    }
}
