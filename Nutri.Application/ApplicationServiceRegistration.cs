using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nutri.Application.Behaviours;
using System.Reflection;

namespace Nutri.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Lee todas las clases que hereden las interfaces del automapper y las va inyectar
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //Buscar todas las clases q referencie de abstractValidation y fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //Los pipelines que realizamos
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
