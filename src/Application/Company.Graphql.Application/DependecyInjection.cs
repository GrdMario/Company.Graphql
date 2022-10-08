namespace Company.Graphql.Application
{
    using Company.Graphql.Blocks.Application.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddApplicationConfiguration(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
