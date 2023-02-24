namespace Company.Graphql.Presentation.Grapql.Internal.Filters
{
    using Company.Graphql.Domain;
    using HotChocolate.Data.Filters;

    internal sealed class PostFilterType: FilterInputType<Post>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Post> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.BlogId);
            descriptor.Field(f => f.Title);
            descriptor.Field(f => f.Url);
            descriptor.Field(f => f.Slug);
            descriptor.Field(f => f.Description);
            descriptor.Field(f => f.Content);
        }
    }
}
