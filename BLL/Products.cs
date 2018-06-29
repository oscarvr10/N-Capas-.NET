using System;
using System.Collections.Generic;
using DAL;
using Entities;

namespace BLL
{
    public class Products
    {
        public Product Create(Product newProduct)
        {
            Product result = null;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                Product res = repository.Get<Product>(p => p.ProductName == newProduct.ProductName);
                if (res == null)
                    result = repository.Create(newProduct);
                //else
                    // Here is anything that indicates product already exists
            }

            return result;
        }

        public Product GetByID(int productID)
        {
            Product result = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                result = repository.Get<Product>(p => p.ProductID == productID);
            }

            return result;
        }

        public bool Update(Product productToUpdate)
        {
            bool result = false;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                Product tmpProduct = repository.Get<Product>(
                    p => p.ProductName == productToUpdate.ProductName
                    && p.ProductID != productToUpdate.ProductID);

                if (tmpProduct == null)
                    result = repository.Update(productToUpdate);
                //else
                // Here is anything that indicates product to update already exists
            }

            return result;
        }

        public bool Delete(int productID)
        {
            bool result = false;

            Product product = GetByID(productID);
            if(product != null)
            {
                if (product.UnitsInStock == 0)
                {
                    using (var repository = RepositoryFactory.CreateRepository())
                    {
                        result = repository.Delete(product);
                    }
                }
                else
                {
                    // Here is anything that indicates product cannot be deleted
                }
            }
            else
            {
                // Here is anything that indicates product does not exist
            }

            return result;
        }

        public List<Product> FilterByCategoryID(int categoryID)
        {
            List<Product> result = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                result = repository.GetAll<Product>(p => p.CategoryID == categoryID);
            }

            return result;
        }
    }
}
