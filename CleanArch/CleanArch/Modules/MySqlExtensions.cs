using Application.Services;
using Domain.User;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Modules
{
    public static class MySqlExtensions
    {
        public static IServiceCollection AddMySql(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CleanArchContext>(
                options => 
                    options.UseMySql(configuration.GetValue<string>("PersistenceModule:DefaultConnection"))
                );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserFactory, EntityFactory>();

            return services;
        }
    }
}
