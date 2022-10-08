namespace Company.Graphql.Application.BlogFeatures.Queries
{
    using Company.Graphql.Application.Contracts.Db.Mssql;
    using Company.Graphql.Blocks.Application.Contracts;
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
        private readonly IQueryRepository<Blog> _repository;
        private readonly IUnitOfWork unitOfWork;

        public GetBlogQueryHandler(IUnitOfWork unitOfWork, IQueryRepository<Blog> repository)
        {
            this.unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IQueryable<Blog>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            this._repository.Entities.WhereIf(request.UserId is not null, blog => blog.UserId == request.UserId);

            return await Task.FromResult(this._repository.Entities.WhereIf(request.UserId is not null, blog => blog.UserId == request.UserId));
        }
    }

    internal sealed class GetBlogsSpecification : SpecificationBase<Blog>
    {
        public GetBlogsSpecification(Guid? userId) : base(blog => userId != null && blog.UserId == userId)
        {
        }
    }
}
