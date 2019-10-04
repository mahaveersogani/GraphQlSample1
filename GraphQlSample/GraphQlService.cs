using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlSample.Entities;
using GraphQlSample.Schema;
using GraphQL;
using Newtonsoft.Json.Linq;

namespace GraphQlSample
{
    public class GraphQlService
    {
        private IDocumentExecuter _documentExecuter;
        private CustomerQuery _customerQuery;
        private IDependencyResolver _dependencyResolver;

        public GraphQlService(IDocumentExecuter documentExecuter, CustomerQuery customerQuery, IDependencyResolver dependencyResolver)
        {
            _documentExecuter = documentExecuter;
            _customerQuery = customerQuery;
            _dependencyResolver = dependencyResolver;
        }

        public async Task<object> ExecuteAsync(GraphQlQuery query)
        {
            var schema = new GraphQL.Types.Schema
            {
                Query = _customerQuery,
                DependencyResolver = _dependencyResolver
            };

            var inputs = query.Variables;

            var result = await _documentExecuter.ExecuteAsync(
                _ =>
                {
                    _.Inputs = inputs;
                    _.Schema = schema;
                    _.Query = query.Query;
                    _.OperationName = query.OperationName;
                });

            return result.Data;
        }

        public async Task<object> ExecuteSchema(GraphQlQuery query)
        {
            var schema = GraphQL.Types.Schema.For(@"
type Customer {
id: Int!
name: String
location: String
}

type Query {
customer(id: Int!): Customer
}",_ =>
            {
                _.Types.Include<Repository>();
                _.Types.Include<Customer>();
                _.DependencyResolver = _dependencyResolver;
            });

            var json = await schema.ExecuteAsync(_ => { _.Query = query.Query; });
            return json;
        }
    }
}
