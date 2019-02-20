using IT_YARD.Models;
using IT_YARD.Repositories;
using System;

namespace UnitTests.Stubs
{
    class ProductStubRepository
    {
        public Repository<Product> Products { get; set; }
        public Product TestProduct { get; set; }

        public ProductStubRepository()
        {
            this.TestProduct = new Product()
            {
                Id = Guid.Parse("9af68d7c-87f1-4d06-828b-78f91d0418e8"),
                Name = "C#",
                Description = "How to learn a language in 30 minutes",
                Price = 100500.0
            };

            this.Products = new Repository<Product>();

            this.Products.Items.Add(TestProduct.Id, TestProduct);
            this.Products.Items.Add(
                Guid.Parse("c0ca2995-903c-4031-9ce4-0eccd9d22db0"),
                new Product()
                {
                    Id = Guid.Parse("c0ca2995-903c-4031-9ce4-0eccd9d22db0"),
                    Name = "Coding guru",
                    Description = "How to write code by thought",
                    Price = 9.99
                }
            );
        }        
    }
}
