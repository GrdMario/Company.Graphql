namespace Company.Graphql.Application.UserFeatures.Queries
{
    using Company.Graphql.Application.Contracts.Db.Mssql;
    using Company.Graphql.Domain;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class GetUsersQuery : IRequest<IQueryable<User>>
    {
    }

    internal sealed class GetUserQueryHandler : IRequestHandler<GetUsersQuery, IQueryable<User>>
    {
        private readonly IQueryRepository<User> repository;

        public GetUserQueryHandler(IQueryRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<IQueryable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.repository.Entities.OrderByDescending(ob => ob.Id));
        }
    }
}
