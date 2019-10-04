using System.Collections.Generic;
using GraphQlSample.Entities;
using GraphQL.Types;

namespace GraphQlSample.Schema
{
    public class CustomerQuery : ObjectGraphType
    {
        private readonly Repository _repository;
        public CustomerQuery(Repository repository)
        {
            _repository = repository;

            Field<CustomerSchema>(
                name: "customer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>() { Name = "id" }),
                resolve: GetCustomerById
                );

            Field<ProductSchema>(
                name: "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>() { Name = "id" }),
                resolve: GetProductById
                );

            Field<ListGraphType<ProductSchema>>(
                name: "products",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: GetProducts
                );

            Field<PurchaseSchema>(
                name: "purchase",
                arguments:new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>{Name = "customerId"}),
                resolve: GetPurchaseDetails
                );
        }

        private object GetProducts(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int?>("id");
            if (id.HasValue)
            {
                return new List<Product> { _repository.GetProductById(id.Value) };
            }
            return _repository.GetAllProducts();
        }

        private object GetPurchaseDetails(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("customerId");            
            return _repository.GetPurchaseByCustomer(id);
        }

        private Product GetProductById(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");
            return _repository.GetProductById(id);
        }

        private Customer GetCustomerById(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");
            return _repository.GetCustomerById(id);
        }
    }
}
