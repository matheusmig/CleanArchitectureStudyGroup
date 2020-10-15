using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.RegisterUser;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Modules
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.Decorate<IRegisterUserUseCase, RegisterUserValidationUseCase>();

            return services;
        }
    }
}
