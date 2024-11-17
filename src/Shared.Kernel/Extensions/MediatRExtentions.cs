using MediatR;
using FluentValidation;
using Shared.Kernel.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ModularMonolithShop.Shared.Kernel.Extensions
{
    public static class MediatRExtentions
    {
        public static IServiceCollection AddMediatRWithAssemblies(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(config => 
            {
                config.RegisterServicesFromAssemblies(assemblies);
                config.AddOpenBehavior(typeof(ValidationPipeline<,>));  
                config.AddOpenBehavior(typeof(LoggingBehaviorPipeline<,>));  
            });
            services.AddValidatorsFromAssemblies(assemblies);
            return services;
        }
    }
}
