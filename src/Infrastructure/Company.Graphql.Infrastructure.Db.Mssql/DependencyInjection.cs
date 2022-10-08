namespace Company.Graphql.Infrastructure.Db.Mssql
{
    using Company.Graphql.Blocks.Application.Contracts;
    using Company.Graphql.Blocks.Infrastructure.Database.Core;
    using Company.Graphql.Infrastructure.Db.Mssql.Internal;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddMssqlDatabaseLayer(this IServiceCollection services, MssqlAdapterSettings settings)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkBase<MssqlDbContext>>();

            services.AddDbContext<MssqlDbContext>(options =>
            {
                options.UseSqlServer(settings.Url);
            }, ServiceLifetime.Transient);

            DatabaseDependencyInjection.AddRepositories<MssqlDbContext>(services);

            return services;
        }
    }

    public class MssqlAdapterSettings
    {
        public const string Key = nameof(MssqlAdapterSettings);

        public string Url { get; set; } = default!;
    }
}
