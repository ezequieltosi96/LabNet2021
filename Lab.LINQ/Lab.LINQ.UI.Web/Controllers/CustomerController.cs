using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.LINQ.Logic.Customer;
using Lab.LINQ.UI.Web.Models.Customer;

namespace Lab.LINQ.UI.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerLogic _customerLogic;

        public CustomerController()
        {
            _customerLogic = new CustomerLogic();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomer(string id)
        {
            var customer = _customerLogic.GetCustomer(id);

            return View(customer);
        }

        public ActionResult GetWashingtonCustomers()
        {
            var customers = _customerLogic.GetWashingtonCustomers();

            return View(customers);
        }

        public ActionResult GetCustomersNamesUpper()
        {
            var customers = _customerLogic.GetCustomersNamesUpper();

            return View(customers);
        }

        public ActionResult GetCustomersNamesLower()
        {
            var customers = _customerLogic.GetCustomersNamesLower();

            return View(customers);
        }

        public ActionResult GetWashingtonCustomersWithOrderDateGreaterThan()
        {
            // se define la fecha requerida por el enunciado
            var date = new DateTime(1997, 01, 01);

            var customers = _customerLogic.GetWashingtonCustomersWithOrderDateGreaterThan(date)
                .Select(c => new CustomerWithOrderViewModel()
                {
                    CustomerID = c.CustomerID,
                    ContactName = c.ContactName,
                    OrderDate = c.OrderDate.ToString("d"),
                    OrderID = c.OrderID,
                    Region = c.Region
                }).ToList();

            return View(customers);
        }

        public ActionResult GetFirstThreeWashingtonCustomers()
        {
            var customers = _customerLogic.GetFirstThreeWashingtonCustomers();

            return View(customers);
        }

        public ActionResult GetCustomersWithOrdersQtty()
        {
            var customers = _customerLogic.GetCustomersWithOrdersQtty()
                .Select(c => new CustomerWithOrderQttyViewModel()
                {
                    CustomerID = c.CustomerID,
                    ContactName = c.ContactName,
                    OrdersQty = c.OrdersQty
                }).ToList();

            return View(customers);
        }
    }
}