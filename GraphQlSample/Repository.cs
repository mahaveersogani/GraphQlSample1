using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlSample.Entities;
using GraphQL;
using Microsoft.AspNetCore.Localization;

namespace GraphQlSample
{
    public class Repository
    {
        [GraphQLMetadata("customer")]
        public Customer GetCustomerById(int id)
        {
            return GetAllCustomers().FirstOrDefault(t => t.Id == id);
        }

        public IList<Customer> GetAllCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id = 1,Name = "Name1",Location = "Bangalore"},
                new Customer{Id = 2,Name = "Name2",Location = "Mysore"},
                new Customer{Id = 3,Name = "Name3",Location = "Hyd"},
                new Customer{Id = 4,Name = "Name4",Location = "Hampi"},
                new Customer{Id = 5,Name = "Name5",Location = "Bangalore"},
                new Customer{Id = 6,Name = "Name6",Location = "Mysore"},
            };
        }

        public Product GetProductById(int id)
        {
            return GetAllProducts().FirstOrDefault(t => t.Id == id);
        }

        public IList<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product{Id = 1,ProductType = ProductType.Mobile},
                new Product{Id = 2,ProductType = ProductType.MusicPlayer},
                new Product{Id = 3,ProductType = ProductType.Mobile},
                new Product{Id = 4,ProductType = ProductType.PersonalComputer},
                new Product{Id = 5,ProductType = ProductType.Mobile},
                new Product{Id = 6,ProductType = ProductType.Tablet},
                new Product{Id = 7,ProductType = ProductType.Mobile},
                new Product{Id = 8,ProductType = ProductType.MusicPlayer},
                new Product{Id = 9,ProductType = ProductType.Mobile}
            };
        }

        public IList<Product> GetPurchaseByCustomer(int id)
        {
            return GetAllProducts();
        }
    }
}
