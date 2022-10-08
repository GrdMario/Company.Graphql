namespace Company.Graphql.Infrastructure.Db.Mssql
{
    using Company.Graphql.Infrastructure.Db.Postgres.Internal;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgresDatabaseLayer(this IServiceCollection services, PostgresAdapterSettings settings)
        {
            services.AddDbContext<PostgresDbContext>(options =>
            {
                options.UseNpgsql(settings.Url);
            }, ServiceLifetime.Transient);

            DatabaseDependencyInjection.AddRepositories<PostgresDbContext>(services);

            return services;
        }
    }

    public class PostgresAdapterSettings
    {
        public const string Key = nameof(PostgresAdapterSettings);

        public string Url { get; set; } = default!;
    }
}
