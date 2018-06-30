using Entities;
using NWindProxyService;
using System.Web.Mvc;

namespace NWind.MVC.Controllers
{
    public class HomeController : Controller
    {
        Proxy proxy = new Proxy();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var products = proxy.GetProductsByCategoryID(id);
            ViewBag.CategoryId = id;
            return View("ProductList", products);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = proxy.GetProductByID(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult CUD(int id = 0)
        {
            var product = new Product();
            if (id != 0)
                product = proxy.GetProductByID(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult CUD(Product product, string btnCreate, string btnUpdate, string btnDelete)
        {   
            ActionResult result = View();

            if(!string.IsNullOrEmpty(btnCreate))
            {
                var tmpProduct = proxy.CreateProduct(product);
                if (tmpProduct != null)
                    result = RedirectToAction("CUD", new { id = tmpProduct.ProductID });
            }
            else if (!string.IsNullOrEmpty(btnUpdate))
            {
                var isUpdated = proxy.UpdateProduct(product);
                if (isUpdated)
                    result = Content("The product was updated successfully.");
                else
                    result = Content("Could not be updated the product.");
            }
            else if (!string.IsNullOrEmpty(btnDelete))
            {
                var isDeleted = proxy.DeleteProduct(product.ProductID);
                if (isDeleted)
                    result = Content("The product was removed successfully.");
                else
                    result = Content("Could not be deleted the product.");
            }

            return result;
        }
    }
}