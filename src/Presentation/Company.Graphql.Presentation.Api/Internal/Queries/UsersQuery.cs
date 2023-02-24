namespace Company.Graphql.Presentation.Grapql.Internal.Queries
{
    using Company.Graphql.Application.UserFeatures.Queries;
    using Company.Graphql.Domain;
    using Company.Graphql.Presentation.Grapql.Internal.Filters;
    using MediatR;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(OperationTypeNames.Query)]
    internal class UsersQuery
    {
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering(typeof(UserFilterType))]
        [UseSorting]
        public async Task<IQueryable<User>> GetUsersAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetUsersQuery(), cancellationToken);
        }

        [UseFirstOrDefault]
        [UseFiltering(typeof(UserFilterType))]
        public async Task<IQueryable<User>> GetUserAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetUsersQuery(), cancellationToken);
        }
    }
}
