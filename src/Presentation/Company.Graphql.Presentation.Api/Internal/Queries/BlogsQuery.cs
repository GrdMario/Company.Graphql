namespace Company.Graphql.Presentation.Grapql.Internal.Queries
{
    using Company.Graphql.Application.BlogFeatures.Queries;
    using Company.Graphql.Domain;
    using Company.Graphql.Presentation.Grapql.Internal.Filters;
    using MediatR;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(OperationTypeNames.Query)]
    internal sealed class BlogsQuery
    {
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering(typeof(BlogFilterType))]
        [UseSorting]
        public async Task<IQueryable<Blog>> GetBlogsAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetBlogsQuery(default), cancellationToken);
        }

        [UseFirstOrDefault]
        [UseFiltering(typeof(BlogFilterType))]
        public async Task<IQueryable<Blog>> GetBlogAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetBlogsQuery(default), cancellationToken);
        }
    }
}
