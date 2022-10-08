namespace Company.Graphql.Presentation.Grapql.Internal.Filters
{
    using Company.Graphql.Domain;
    using HotChocolate.Data.Filters;

    internal sealed class UserFilterType : FilterInputType<User>
    {
        protected override void Configure(IFilterInputTypeDescriptor<User> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.Email);
            descriptor.Field(f => f.UserName);
            descriptor.Field(f => f.Address);
            descriptor.Field(f => f.ProfilePicture);
        }
    }
}
