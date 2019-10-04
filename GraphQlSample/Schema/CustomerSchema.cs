using GraphQlSample.Entities;
using GraphQL.Types;

namespace GraphQlSample.Schema
{
    public class CustomerSchema : ObjectGraphType<Customer>
    {
        public CustomerSchema()
        {
            Field(t => t.Id).Description("ID of customer");
            Field(t => t.Name).Description("Name of customer");
            Field(t => t.Location).Description("Location of customer");
        }
    }
}
