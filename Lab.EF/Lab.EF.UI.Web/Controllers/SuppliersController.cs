using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic.Supplier;

namespace Lab.EF.UI.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SupplierLogic _supplierLogic;

        public SuppliersController()
        {
            _supplierLogic = new SupplierLogic();
        }

        public ActionResult Index()
        {
            var suppliers = _supplierLogic.GetAll();

            return View(suppliers);
        }

        public ActionResult Detail(int id)
        {
            var supplier = _supplierLogic.Get(id);

            if (supplier == null) return RedirectToAction("Index");

            return View(supplier);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                if (!ModelState.IsValid) return View(supplier);

                _supplierLogic.Add(supplier);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(supplier);
            }
        }

        public ActionResult Edit(int id)
        {
            var supplier = _supplierLogic.Get(id);

            if (supplier != null) return View(supplier);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            try
            {
                if (!ModelState.IsValid) return View(supplier);

                _supplierLogic.Update(supplier);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(supplier);
            }
        }

        public ActionResult Delete(int id)
        {
            _supplierLogic.Delete(id);

            return RedirectToAction("Index");
        }
    }
}