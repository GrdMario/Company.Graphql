namespace Company.Graphql.Presentation.Grapql.Internal.Types
{
    using Company.Graphql.Domain;

    internal sealed class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.BindFieldsImplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.BlogId);
            descriptor.Field(f => f.Title);
            descriptor.Field(f => f.Description);
            descriptor.Field(f => f.Content);
            descriptor.Field(f => f.Url);
            descriptor.Field(f => f.Slug);
        }
    }
}
