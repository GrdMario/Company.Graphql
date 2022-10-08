namespace Company.Graphql.Presentation.Grapql.Internal.Resolvers
{
    using Company.Graphql.Application.BlogFeatures.Queries;
    using Company.Graphql.Domain;
    using MediatR;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class UserResolvers
    {
        public async Task<IQueryable<Blog>> GetBlogsAsync([Parent] User user, [Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetBlogsQuery(user.Id), cancellationToken);
        }
    }
}
