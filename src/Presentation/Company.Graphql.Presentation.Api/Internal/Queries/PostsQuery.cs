namespace Company.Graphql.Presentation.Grapql.Internal.Queries
{
    using Company.Graphql.Application.PostsFeatures.Queries;
    using Company.Graphql.Domain;
    using Company.Graphql.Presentation.Grapql.Internal.Filters;
    using MediatR;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(OperationTypeNames.Query)]
    internal sealed class PostsQuery
    {
        public async Task<IQueryable<Post>> GetPostsAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetPostsQuery(default), cancellationToken);
        }

        public async Task<IQueryable<Post>> GetPostAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetPostsQuery(default), cancellationToken);
        }
    }
}
