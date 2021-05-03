using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.LINQ.Logic.Product;

namespace Lab.LINQ.UI.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductLogic _productLogic;

        public ProductController()
        {
            _productLogic = new ProductLogic();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOutOfStock()
        {
            var products = _productLogic.GetOutOfStock();

            return View(products);
        }

        public ActionResult GetProductsInStockPriceHigherThan(decimal price)
        {
            var products = _productLogic.GetProductsInStockPriceHigherThan(price);

            ViewBag.Price = price;
            return View(products);
        }

        public ActionResult GetProduct(int id)
        {
            var product = _productLogic.GetProduct(id);

            return View(product);
        }

        public ActionResult GetProductsOrderByName()
        {
            var products = _productLogic.GetProductsOrderByName();

            return View(products);
        }

        public ActionResult GetProductsOrderByStockDesc()
        {
            var products = _productLogic.GetProductsOrderByStockDesc();

            return View(products);
        }

        public ActionResult GetProductsWithCategories()
        {
            var products = _productLogic.GetProductsWithCategories();

            return View(products);
        }

        public ActionResult GetFirstProduct()
        {
            var product = _productLogic.GetFirstProduct();

            return View(product);
        }
    }
}