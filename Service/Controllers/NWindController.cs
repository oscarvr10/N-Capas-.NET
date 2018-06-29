using BLL;
using Entities;
using SCL;
using System.Collections.Generic;
using System.Web.Http;

namespace Service.Controllers
{
    public class NWindController : ApiController, IService
    {
        [HttpPost]
        public Category CreateCategory(Category newCategory)
        {
            var businessLogic = new Categories();
            var createdCategory = businessLogic.Create(newCategory);
            return createdCategory;
        }

        [HttpPost]
        public Product CreateProduct(Product newProduct)
        {
            var businessLogic = new Products();
            var createdProduct = businessLogic.Create(newProduct);
            return createdProduct;
        }

        [HttpGet]
        public bool DeleteCategory(int ID)
        {
            var businessLogic = new Categories();
            var result = businessLogic.Delete(ID);
            return result;
        }

        [HttpGet]
        public bool DeleteProduct(int ID)
        {
            var businessLogic = new Products();
            var result = businessLogic.Delete(ID);
            return result;
        }

        [HttpGet]
        public List<Category> GetCategories()
        {
            var businessLogic = new Categories();
            var result = businessLogic.GetCategories();
            return result;
        }

        [HttpGet]
        public Category GetCategoryByID(int ID)
        {
            var businessLogic = new Categories();
            var result = businessLogic.GetByID(ID);
            return result;
        }

        [HttpGet]
        public Product GetProductByID(int ID)
        {
            var businessLogic = new Products();
            var result = businessLogic.GetByID(ID);
            return result;
        }

        [HttpGet]
        public List<Product> GetProductsByCategoryID(int ID)
        {
            var businessLogic = new Products();
            var result = businessLogic.FilterByCategoryID(ID);
            return result;
        }

        [HttpPost]
        public bool UpdateCategory(Category categoryToUpdate)
        {
            var businessLogic = new Categories();
            var result = businessLogic.Update(categoryToUpdate);
            return result;
        }

        [HttpPost]
        public bool UpdateProduct(Product productToUpdate)
        {
            var businessLogic = new Products();
            var result = businessLogic.Update(productToUpdate);
            return result;
        }
    }
}
