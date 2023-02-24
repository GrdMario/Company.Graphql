namespace Company.Graphql.Presentation.Grapql.Internal.Types
{
    using Company.Graphql.Domain;
    using Company.Graphql.Presentation.Grapql.Internal.Filters;
    using Company.Graphql.Presentation.Grapql.Internal.Resolvers;

    internal sealed class BlogType : ObjectType<Blog>
    {
        protected override void Configure(IObjectTypeDescriptor<Blog> descriptor)
        {
            descriptor.BindFieldsImplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.Title);
            descriptor.Field(f => f.Description);

            descriptor
                .Field(p => p.Posts)
                .ResolveWith<PostResolvers>(p => p.GetPostsAsync(default!, default!, default))
                .UseOffsetPaging()
                .UseProjection()
                .UseFiltering<PostFilterType>()
                .UseSorting();
        }
    }
}