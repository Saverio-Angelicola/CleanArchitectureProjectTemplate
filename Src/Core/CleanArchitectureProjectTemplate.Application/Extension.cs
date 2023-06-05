using CleanArchitectureProjectTemplate.Application.Commons.Bases.Command;
using CleanArchitectureProjectTemplate.Application.Commons.Bases.Query;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureProjectTemplate.Application
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            // register automatically command handler in IOC Container
            services.Scan(s => s.FromCallingAssembly()
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            // register automatically query handler in IOC Container
            services.Scan(s => s.FromCallingAssembly()
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

    }
}
