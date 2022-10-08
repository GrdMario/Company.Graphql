namespace Company.Graphql.Presentation.Grapql
{
    using Company.Graphql.Presentation.Grapql.Internal.Queries;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependecyInjection
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddQueryType()
                .AddGrapqlTypes();

            return services;
        }
    }
}
