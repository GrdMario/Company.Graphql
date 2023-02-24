namespace Company.Graphql.Presentation.Grapql.Internal.Types
{
    using Company.Graphql.Domain;
    using Company.Graphql.Presentation.Grapql.Internal.Resolvers;

    internal sealed class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.UserName);
            descriptor.Field(f => f.Email);
            descriptor.Field(f => f.Address);
            descriptor.Field(f => f.ProfilePicture);

            descriptor
                .Field("blogs")
                .ResolveWith<UserResolvers>(action => action.GetBlogsAsync(default!, default!, default!))
                .UseOffsetPaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting();
        }
    }
}
