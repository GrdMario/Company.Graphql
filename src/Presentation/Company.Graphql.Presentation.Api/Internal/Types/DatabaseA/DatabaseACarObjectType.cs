namespace Company.Graphql.Presentation.Grapql.Internal.Types.DatabaseA
{
    using Company.Graphql.Domain.DatabaseA;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DatabaseACarObjectType : ObjectType<Car>
    {
        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            descriptor.BindFieldsExplicitly();
        }
    }
}
