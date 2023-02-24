namespace Company.Graphql.Application.BlogFeatures.Queries
{
    using Company.Graphql.Application.Contracts.Db.Mssql;
    using Company.Graphql.Blocks.Common.Extensions;
    using Company.Graphql.Domain;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class GetBlogsQuery : IRequest<IQueryable<Blog>>
    {
        public GetBlogsQuery(Guid? userId)
        {
            this.UserId = userId;
        }

        public Guid? UserId { get; }
    }

    internal sealed class GetBlogQueryHandler : IRequestHandler<GetBlogsQuery, IQueryable<Blog>>
    {
        private readonly IQueryRepository<Blog> repository;

        public GetBlogQueryHandler(IQueryRepository<Blog> repository)
        {
            this.repository = repository;
        }

        public async Task<IQueryable<Blog>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.repository.Entities
                .WhereIf(request.UserId != null, blog => blog.UserId == request.UserId)
                .OrderByDescending(ob => ob.Id));
        }
    }
}
