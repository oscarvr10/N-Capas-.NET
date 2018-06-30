using BLL;
using Entities;
using System.Web.Mvc;

namespace NWind.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var proxy = new Products();
            var products = proxy.FilterByCategoryID(id);
            ViewBag.CategoryId = id;
            return View("ProductList", products);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var proxy = new Products();
            var product = proxy.GetByID(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult CUD(int id = 0)
        {
            var proxy = new Products();
            var product = new Product();
            if (id != 0)
                product = proxy.GetByID(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult CUD(Product product, string btnCreate, string btnUpdate, string btnDelete)
        {   
            ActionResult result = View();
            var proxy = new Products();
            if (!string.IsNullOrEmpty(btnCreate))
            {
                var tmpProduct = proxy.Create(product);
                if (tmpProduct != null)
                    result = RedirectToAction("CUD", new { id = tmpProduct.ProductID });
            }
            else if (!string.IsNullOrEmpty(btnUpdate))
            {
                var isUpdated = proxy.Update(product);
                if (isUpdated)
                    result = Content("The product was updated successfully.");
                else
                    result = Content("Could not be updated the product.");
            }
            else if (!string.IsNullOrEmpty(btnDelete))
            {
                var isDeleted = proxy.Delete(product.ProductID);
                if (isDeleted)
                    result = Content("The product was removed successfully.");
                else
                    result = Content("Could not be deleted the product.");
            }

            return result;
        }
    }
}