using GraphQlSample.Entities;
using GraphQL.Types;

namespace GraphQlSample.Schema
{
    public class ProductSchema : ObjectGraphType<Product>
    {
        public ProductSchema()
        {
            Field(t => t.Id).Description("ID of product");
            Field(t => t.ProductType, false, typeof(ProductTypeEnum)).Description("Type of product");
        }
    }
}