using DAL;
using Entities;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddCategoryAndProduct();
            //AddProduct();
            //GetAndUpdate();
            //GetList();
            SearchAndDelete();
            Console.ReadLine();
        }
        
        static void AddCategoryAndProduct()
        {
            var c = new Category();
            c.CategoryName = "Vegetables";
            c.Description = "Products of the vegetable category";
            
            var lettuce = new Product()
            {
                ProductName = "Lettuce",
                UnitPrice = 20,
                UnitsInStock = 100
            };

            c.Products.Add(lettuce);

            using (var repository = RepositoryFactory.CreateRepository())
            {
                repository.Create(c);
            }
            Console.WriteLine($"Category: {c.CategoryID}, Product: {lettuce.ProductID}");
        }

        static void AddProduct()
        {
            var carrot = new Product()
            {
                CategoryID = 1,
                ProductName = "Carrot",
                UnitPrice = 15,
                UnitsInStock = 150
            };
            using (var repository = RepositoryFactory.CreateRepository())
            {
                repository.Create(carrot);
            }

            Console.WriteLine($"Product: {carrot.ProductID}");
        }

        static void GetAndUpdate()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var product = repository.Get<Product>(p => p.ProductID == 2);
                if (product != null)
                {
                    Console.WriteLine($"Product to update: {product.ProductName}");
                    product.ProductName = product.ProductName + "*****";
                    repository.Update(product);
                    Console.WriteLine("The product name was updated successfully.");
                }
                else
                {
                    Console.WriteLine("The product was not found.");
                }
            }
        }

        static void GetList()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var products = repository.GetAll<Product>(p => p.CategoryID == 1);
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.ProductName}");
                }
            }
        }

        static void SearchAndDelete()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var product = repository.Get<Product>(p => p.ProductID == 2);
                if (product != null)
                {
                    Console.WriteLine($"Product to delete: {product.ProductName}");
                    repository.Delete(product);
                    Console.WriteLine("The product was deleted successfully.");
                }
                else
                {
                    Console.WriteLine("The product was not found.");
                }
            }
        }
    }
}
