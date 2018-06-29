using Entities;
using System.Collections.Generic;
namespace SCL
{
    public interface IService
    {
        Product CreateProduct(Product newProduct);
        Product GetProductByID(int productID);
        bool UpdateProduct(Product productToUpdate);
        bool DeleteProduct(int productID);
        List<Product> GetProductsByCategoryID(int categoryID);

        Category CreateCategory(Category newCategory);
        Category GetCategoryByID(int categoryID);
        bool UpdateCategory(Category categoryToUpdate);
        bool DeleteCategory(int categoryID);
        List<Category> GetCategories();
    }
}
