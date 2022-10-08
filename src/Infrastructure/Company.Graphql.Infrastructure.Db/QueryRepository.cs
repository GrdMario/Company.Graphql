namespace Company.Graphql.Infrastructure.Db
{
    using Company.Graphql.Application.Contracts.Db.Mssql;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class QueryRepository<TDbContext, TEntity> : IQueryRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;

        public QueryRepository(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TEntity> Entities => this.dbContext.Set<TEntity>().AsNoTracking();
    }
}