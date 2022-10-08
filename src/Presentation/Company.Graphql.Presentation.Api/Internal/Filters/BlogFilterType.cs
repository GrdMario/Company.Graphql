namespace Company.Graphql.Presentation.Grapql.Internal.Filters
{
    using Company.Graphql.Domain;
    using HotChocolate.Data.Filters;

    internal sealed class BlogFilterType : FilterInputType<Blog>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Blog> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.Title);
            descriptor.Field(f => f.Description);
        }
    }
}
