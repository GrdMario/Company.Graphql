namespace Company.Graphql.Presentation.Grapql.Internal.Types
{
    using Company.Graphql.Domain;
    using Company.Graphql.Presentation.Grapql.Internal.Resolvers;

    internal sealed class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(u => u.Id);
            descriptor.Field(u => u.UserName);
            descriptor.Field(u => u.Address);
            descriptor.Field(u => u.Email);

            descriptor.Field("blogs")
                .UsePaging()
                .ResolveWith<UserResolvers>(action => action.GetBlogsAsync(default!, default!, default!));
        }
    }
}
