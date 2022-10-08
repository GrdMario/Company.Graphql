namespace Company.Graphql.Infrastructure.Db.Mssql.Internal
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    internal sealed class MssqlDbContextFactory : IDesignTimeDbContextFactory<MssqlDbContext>
    {
        public MssqlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = BuildConfiguration(args);

            var optionsBuilder = new DbContextOptionsBuilder<MssqlDbContext>();
            var connectionString = configuration.GetSection(args[0]).Value;

            optionsBuilder
                .UseSqlServer(connectionString);

            MssqlDbContext instance = new(optionsBuilder.Options);

            if (instance is null)
            {
                throw new InvalidOperationException($"Unable to initialize {nameof(MssqlDbContext)} instance.");
            }

            return instance;
        }

        private static IConfigurationRoot BuildConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(args[2])
                .AddJsonFile(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(args[1])
                .AddCommandLine(args)
                .Build();
        }
    }
}

