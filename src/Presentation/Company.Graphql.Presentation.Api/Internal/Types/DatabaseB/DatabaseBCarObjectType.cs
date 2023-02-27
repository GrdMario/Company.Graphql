namespace Company.Graphql.Presentation.Grapql.Internal.Types.DatabaseB
{
    using Company.Graphql.Domain.DatabaseB;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DatabaseBCarObjectType : ObjectType<Car>
    {
        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            descriptor.BindFieldsExplicitly();
        }
    }
}
