namespace Company.Graphql.Application.Contracts.Db.Mssql
{
    using System.Linq;

    public interface IQueryRepository<T>
    {
        IQueryable<T> Entities { get; }
    }
}
