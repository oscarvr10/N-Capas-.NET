using Entities;
using Newtonsoft.Json;
using SCL;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NWindProxyService
{
    public class Proxy : IService
    {
        // Replace 'localhost' with your IP Address here and 'Project URL' from Service project properties.
        // Also replace it in 'bindingInformation' property, it is within site node called 'Service'
        // from applicationhost.config (it is located in .vs/config path from solution folder)
        const string BaseURL = "http://localhost:58349/";
        const string JSONHeader = "application/json";

        #region HTTP Methods

        public async Task<T> SendPost<T,PostData>(string requestURI, PostData data)
        {
            T result = default(T);

            using (var client = new HttpClient())
            {
                try
                {
                    requestURI = BaseURL + requestURI;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSONHeader));
                    var jsonData = JsonConvert.SerializeObject(data);

                    HttpResponseMessage response = 
                        await client.PostAsync(requestURI, new StringContent(jsonData, Encoding.UTF8, JSONHeader));
                    var resultAPI = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(resultAPI);
                }
                catch (Exception ex)
                {
                    
                }
            }

            return result;
        }

        public async Task<T> SendGet<T>(string requestURI)
        {
            T result = default(T);

            using (var client = new HttpClient())
            {
                try
                {
                    requestURI = BaseURL + requestURI;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSONHeader));

                    var resultJSON = await client.GetStringAsync(requestURI);
                    result = JsonConvert.DeserializeObject<T>(resultJSON);
                }
                catch (Exception ex)
                {
                    
                }
            }

            return result;
        }
        
        #endregion
        
        #region API Methods

        public async Task<List<Product>> GetProductsByCategoryIDAsync(int ID)
        {
            return await SendGet<List<Product>>($"{Endpoints.GetProductsByCategoryIdURI}/{ID}");
        }

        public async Task<Product> GetProductByIDAsync(int ID)
        {
            return await SendGet<Product>($"{Endpoints.GetProductURI}/{ID}");
        }

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            return await SendPost<Product, Product>(Endpoints.CreateProductURI, newProduct);
        }

        public async Task<bool> UpdateProductAsync(Product productToUpdate)
        {
            return await SendPost<bool, Product>(Endpoints.UpdateProductURI, productToUpdate);
        }

        public async Task<bool> DeleteProductByIDAsync(int ID)
        {
            return await SendGet<bool>($"{Endpoints.DeleteProductURI}/{ID}");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await SendGet<List<Category>>(Endpoints.GetCategoriesURI);
        }

        public async Task<Category> GetCategoryByIDAsync(int ID)
        {
            return await SendGet<Category>($"{Endpoints.GetCategoryURI}/{ID}");
        }

        public async Task<Category> CreateCategoryAsync(Category newCategory)
        {
            return await SendPost<Category, Category>(Endpoints.CreateCategoryURI, newCategory);
        }

        public async Task<bool> UpdateCategoryAsync(Category categoryToUpdate)
        {
            return await SendPost<bool, Category>(Endpoints.UpdateCategoryURI, categoryToUpdate);
        }

        public async Task<bool> DeleteCategoryByIDAsync(int ID)
        {
            return await SendGet<bool>($"{Endpoints.DeleteCategoryURI}/{ID}");
        }

        #endregion

        #region IService Implementations

        public List<Product> GetProductsByCategoryID(int categoryID)
        {
            List <Product> result = null;
            Task.Run(async () => result = await GetProductsByCategoryIDAsync(categoryID)).Wait();
            return result;
        }

        public Product GetProductByID(int productID)
        {
            Product result = null;
            Task.Run(async () => result = await GetProductByIDAsync(productID)).Wait();
            return result;
        }

        public Product CreateProduct(Product newProduct)
        {
            Product result = null;
            Task.Run(async() => result = await CreateProductAsync(newProduct)).Wait();
            return result;
        }

        public bool UpdateProduct(Product productToUpdate)
        {
            bool result = false;
            Task.Run(async () => result = await UpdateProductAsync(productToUpdate)).Wait();
            return result;
        }

        public bool DeleteProduct(int productID)
        {
            bool result = false;
            Task.Run(async () => result = await DeleteProductByIDAsync(productID)).Wait();
            return result;
        }

        public List<Category> GetCategories()
        {
            List<Category> result = null;
            Task.Run(async () => result = await GetCategoriesAsync()).Wait();
            return result;
        }

        public Category GetCategoryByID(int categoryID)
        {
            Category result = null;
            Task.Run(async () => result = await GetCategoryByIDAsync(categoryID)).Wait();
            return result;
        }

        public Category CreateCategory(Category newCategory)
        {
            Category result = null;
            Task.Run(async () => result = await CreateCategoryAsync(newCategory)).Wait();
            return result;
        }

        public bool UpdateCategory(Category categoryToUpdate)
        {
            bool result = false;
            Task.Run(async () => result = await UpdateCategoryAsync(categoryToUpdate)).Wait();
            return result;
        }

        public bool DeleteCategory(int categoryID)
        {
            bool result = false;
            Task.Run(async () => result = await DeleteCategoryByIDAsync(categoryID)).Wait();
            return result;
        }

        #endregion
    }

    public class Endpoints
    {
        public const string GetProductURI = "api/nwind/getproductbyid";
        public const string GetProductsByCategoryIdURI = "api/nwind/getproductsbycategoryid";
        public const string CreateProductURI = "api/nwind/createproduct";
        public const string UpdateProductURI = "api/nwind/updateproduct";
        public const string DeleteProductURI = "api/nwind/deleteproduct";

        public const string GetCategoryURI = "api/nwind/getcategorybyid";
        public const string GetCategoriesURI = "api/nwind/getcategories";   
        public const string CreateCategoryURI = "api/nwind/createcategory";
        public const string UpdateCategoryURI = "api/nwind/updatecategory";
        public const string DeleteCategoryURI = "api/nwind/deletecategory";
    }
}
