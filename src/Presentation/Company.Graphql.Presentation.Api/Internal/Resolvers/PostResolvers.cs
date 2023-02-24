namespace Company.Graphql.Presentation.Grapql.Internal.Resolvers
{
    using Company.Graphql.Application.PostsFeatures.Queries;
    using Company.Graphql.Domain;
    using MediatR;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class PostResolvers
    {
        public async Task<IQueryable<Post>> GetPostsAsync([Parent] Blog blog, [Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetPostsQuery(blog.Id), cancellationToken);
        }
    }
}
