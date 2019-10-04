using System.Collections.Generic;
using System.Linq;
using GraphQlSample.Entities;
using GraphQL.Types;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraphQlSample.Schema
{
    public class PurchaseSchema : ObjectGraphType<IList<Product>>
    {
        public PurchaseSchema()
        {
            Field<ListGraphType<ProductSchema>>(
                name: "products",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: GetProducts
            );
        }

        private object GetProducts(ResolveFieldContext<IList<Product>> context)
        {
            var id = context.GetArgument<int?>("id");
            if (id.HasValue)
            {
                return context.Source.Where(t=>t.Id==id.Value);                
            }
            return context.Source ;
        }
    }
}
