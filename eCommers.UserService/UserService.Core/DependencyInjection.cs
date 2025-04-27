using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Core.Mapper;
using UserService.Core.ServiceContracts;
using UserService.Core.Services;
using UserService.Core.Validators;

namespace UserService.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserServices>();
            return services;
        }
        /// <summary>
        /// Mapper Profile
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMapperProfile));
            return services;
        }
        /// <summary>
        /// Fluent Validator
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFluentValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}
