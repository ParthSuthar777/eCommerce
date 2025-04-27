using Microsoft.Extensions.DependencyInjection;
using UserService.Core.RepositoryContracts;
using UserServices.Infrastructure.DbContext;
using UserServices.Infrastructure.Repository;

namespace UserServices.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Register Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<DapperDbContext>();
            return services;
        }

    }
}
