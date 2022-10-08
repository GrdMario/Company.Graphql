namespace Company.Graphql.Infrastructure.Db.Postgres.Internal
{
    using Company.Graphql.Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    internal sealed class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; } = default!;
    }
}

