namespace Company.Graphql.Infrastructure.Db.Mssql.Internal
{
    using Company.Graphql.Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    internal sealed class MssqlDbContext : DbContext
    {
        public MssqlDbContext(DbContextOptions<MssqlDbContext> options) : base(options)
        {
        }

        public MssqlDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Blog> Blogs { get; } = default!;

        public DbSet<Post> Posts { get; } = default!;
    }
}

