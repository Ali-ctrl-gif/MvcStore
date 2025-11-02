using Microsoft.AspNetCore.Mvc;
using MvcStore.Models;

namespace MvcStore.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product {Id = 1, Name = "Laptop" , Type = "Electronics" , Price = 80000000M,Quantity = 10},
            new Product {Id = 2, Name = "AirPad" , Type = "Electronics" , Price = 10000000M,Quantity = 15},
            new Product {Id = 3, Name = "Desk" , Type = "Furniture" , Price = 2000000M , Quantity = 20}
        };
        public ActionResult Index()
        {
            return View(_products);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = _products.Find(b => b.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return RedirectToAction("Index")    ;
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _products.Find(e => e.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product Updateproduct)
        {
            var product = _products.Find(c => c.Id == Updateproduct.Id);
            if(product == null)
            {
                return NotFound();
            }
            product.Id = Updateproduct.Id;
            product.Name = Updateproduct.Name;
            product.Price = Updateproduct.Price;
            product.Quantity = Updateproduct.Quantity;

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _products.Find(d => d.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult DeleteDeleteConfirmed(int id)
        {
            var product = _products.Find(d => d.Id == id);
            if(product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction("index");
        }
    }   
}