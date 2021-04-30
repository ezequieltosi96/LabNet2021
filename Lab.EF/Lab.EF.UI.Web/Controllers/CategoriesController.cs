using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic.Category;

namespace Lab.EF.UI.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryLogic _categoryLogic;

        public CategoriesController()
        {
            _categoryLogic = new CategoryLogic();
        }

        public ActionResult Index()
        {
            var categories = _categoryLogic.GetAll();

            return View(categories);
        }

        public ActionResult Detail(int id)
        {
            var category = _categoryLogic.Get(id);

            if (category == null) return RedirectToAction("Index");

            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid) return View(category);

                _categoryLogic.Add(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryLogic.Get(id);

            if (category != null) return View(category);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (!ModelState.IsValid) return View(category);

                _categoryLogic.Update(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        public ActionResult Delete(int id)
        {
            _categoryLogic.Delete(id);

            return RedirectToAction("Index");
        }
    }
}