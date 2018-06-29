using DAL;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class Categories
    {
        public Category Create(Category newCategory)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                newCategory = repository.Create(newCategory);
            }

            return newCategory;
        }

        public Category GetByID(int categoryID)
        {
            Category result = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                result = repository.Get<Category>(p => p.CategoryID == categoryID);
            }

            return result;
        }

        public bool Update(Category categoryToUpdate)
        {
            bool result = false;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                Category tmpCategory = repository.Get<Category>(
                    p => p.CategoryName == categoryToUpdate.CategoryName
                    && p.CategoryID != categoryToUpdate.CategoryID);

                if (tmpCategory == null)
                    result = repository.Update(categoryToUpdate);
                //else
                // Here is anything that indicates category to update already exists
            }

            return result;
        }

        public bool Delete(int categoryID)
        {
            bool result = false;

            Category category = GetByID(categoryID);
            if (category != null)
            {
                if (category.Products.Count == 0)
                {
                    using (var repository = RepositoryFactory.CreateRepository())
                    {
                        result = repository.Delete(category);
                    }
                }
                else
                {
                    // Here is anything that indicates category cannot be deleted
                }
            }
            else
            {
                // Here is anything that indicates category does not exist
            }

            return result;
        }

        public List<Category> GetCategories()
        {
            List<Category> result = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                result = repository.GetAll<Category>(p => p.CategoryID >= 0);
            }

            return result;
        }
    }
}
