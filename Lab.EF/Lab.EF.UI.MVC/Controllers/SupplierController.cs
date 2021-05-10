using System;
using System.Linq;
using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic.Supplier;
using Lab.EF.UI.MVC.Models.Supplier;

namespace Lab.EF.UI.MVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierLogic _supplierLogic;

        public SupplierController()
        {
            _supplierLogic = new SupplierLogic();
        }

        public ActionResult Index()
        {
            var supplierModels = _supplierLogic.GetAll()
                .Select(s => new SupplierListViewModel()
                {
                    Id = s.SupplierID,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    Phone = s.Phone
                });

            return View(supplierModels);
        }

        public ActionResult Details(int id)
        {
            try
            {
                var supplier = _supplierLogic.Get(id);

                if (supplier == null) return View("Error");

                var model = new SupplierCrudViewModel()
                {
                    Id = supplier.SupplierID,
                    Address = supplier.Address,
                    City = supplier.City,
                    CompanyName = supplier.CompanyName,
                    ContactName = supplier.ContactName,
                    ContactTitle = supplier.ContactTitle,
                    Country = supplier.Country,
                    Fax = supplier.Fax,
                    HomePage = supplier.HomePage,
                    Phone = supplier.Phone,
                    PostalCode = supplier.PostalCode,
                    Region = supplier.Region
                };

                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public ActionResult CreateOrEdit(int id = 0)
        {
            try
            {
                var model = new SupplierCrudViewModel();

                if (id == 0) // creating new register
                {
                    model.Id = 0;
                    ViewBag.ActionName = "Create";
                }
                else // editing existent register
                {
                    var supplier = _supplierLogic.Get(id);

                    if (supplier == null) return View("Error");

                    model.Id = supplier.SupplierID;
                    model.Address = supplier.Address;
                    model.City = supplier.City;
                    model.CompanyName = supplier.CompanyName;
                    model.ContactName = supplier.ContactName;
                    model.ContactTitle = supplier.ContactTitle;
                    model.Country = supplier.Country;
                    model.Fax = supplier.Fax;
                    model.HomePage = supplier.HomePage;
                    model.Phone = supplier.Phone;
                    model.PostalCode = supplier.PostalCode;
                    model.Region = supplier.Region;

                    ViewBag.ActionName = "Edit";
                }

                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(SupplierCrudViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ActionName = "Create";
                    if (vm.Id != 0) ViewBag.ActionName = "Edit";

                    return View(vm);
                }

                if (vm.Id == 0)
                {
                    _supplierLogic.Add(new Supplier()
                    {
                        Address = vm.Address,
                        City = vm.City,
                        CompanyName = vm.CompanyName,
                        ContactName = vm.ContactName,
                        ContactTitle = vm.ContactTitle,
                        Country = vm.Country,
                        Fax = vm.Fax,
                        HomePage = vm.HomePage,
                        Phone = vm.Phone,
                        PostalCode = vm.PostalCode,
                        Region = vm.Region
                    });
                }
                else
                {
                    _supplierLogic.Update(new Supplier()
                    {
                        SupplierID = vm.Id,
                        Address = vm.Address,
                        City = vm.City,
                        CompanyName = vm.CompanyName,
                        ContactName = vm.ContactName,
                        ContactTitle = vm.ContactTitle,
                        Country = vm.Country,
                        Fax = vm.Fax,
                        HomePage = vm.HomePage,
                        Phone = vm.Phone,
                        PostalCode = vm.PostalCode,
                        Region = vm.Region
                    });
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _supplierLogic.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}