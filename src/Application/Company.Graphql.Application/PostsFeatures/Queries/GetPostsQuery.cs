namespace Company.Graphql.Application.PostsFeatures.Queries
{
    using Company.Graphql.Application.Contracts.Db.Mssql;
    using Company.Graphql.Blocks.Common.Extensions;
    using Company.Graphql.Domain;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class GetPostsQuery : IRequest<IQueryable<Post>>
    {
        public GetPostsQuery(Guid? blogId)
        {
            this.BlogId = blogId;
        }

        public Guid? BlogId { get; }
    }

    internal sealed class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IQueryable<Post>>
    {
        private readonly IQueryRepository<Post> repository;

        public GetPostsQueryHandler(IQueryRepository<Post> repository)
        {
            this.repository = repository;
        }

        public async Task<IQueryable<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.repository.Entities
                .WhereIf(request.BlogId is not null, post => post.BlogId == request.BlogId)
                .OrderByDescending(ob => ob.Id));
        }
    }
}
