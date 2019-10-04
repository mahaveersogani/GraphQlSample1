using GraphQL;

namespace GraphQlSample.Schema
{
    public class MySchema: GraphQL.Types.Schema
    {
        public MySchema(IDependencyResolver resolver):base(resolver)
        {
            Query = resolver.Resolve<CustomerQuery>();
        }
    }
}
