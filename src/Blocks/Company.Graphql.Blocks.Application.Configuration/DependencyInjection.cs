namespace Company.Graphql.Blocks.Application.Configuration
{
    using Company.Graphql.Blocks.Application.Contracts;
    using Company.Graphql.Blocks.Application.Core.Adapters;
    using Company.Graphql.Blocks.Application.Core.Behaviors;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using System.Reflection;

    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddHttpContextAccessor();

            services.TryAddSingleton<IHttpContextAccessorAdapter, HttpContextAccessorAdapter>();

            return services;
        }
    }
}
