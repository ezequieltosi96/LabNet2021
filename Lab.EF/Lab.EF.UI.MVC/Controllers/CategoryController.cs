using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic.Category;
using Lab.EF.UI.MVC.Helpers;
using Lab.EF.UI.MVC.Models.Category;

namespace Lab.EF.UI.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryLogic _categoryLogic;

        public CategoryController()
        {
            _categoryLogic = new CategoryLogic();
        }

        private IEnumerable<CategoryViewModel> GetAllViewModels()
        {
            return _categoryLogic.GetAll()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.CategoryID,
                    Name = c.CategoryName,
                    Description = c.Description
                }).ToList();
        }

        public ActionResult Index()
        {
            var categoryModels = this.GetAllViewModels();

            return View(categoryModels);
        }

        public ActionResult Details(int id)
        {
            try
            {
                var category = _categoryLogic.Get(id);

                if (category == null) return View("Error");

                var model = new CategoryViewModel()
                {
                    Id = category.CategoryID,
                    Name = category.CategoryName,
                    Description = category.Description
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
                var model = new CategoryViewModel();

                if (id == 0) // creating new register
                {
                    model.Id = 0;
                    ViewBag.ActionName = "Create";
                }
                else // editing existent register
                {
                    var category = _categoryLogic.Get(id);

                    if (category == null) return View("Error");

                    model.Id = category.CategoryID;
                    model.Name = category.CategoryName;
                    model.Description = category.Description;

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
        public ActionResult CreateOrEdit(CategoryViewModel vm)
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
                    _categoryLogic.Add(new Category()
                    {
                        CategoryName = vm.Name,
                        Description = vm.Description
                    });
                }
                else
                {
                    _categoryLogic.Update(new Category()
                    {
                        CategoryID = vm.Id,
                        CategoryName = vm.Name,
                        Description = vm.Description
                    });
                }

                return Json(new
                {
                    isValid = true,
                    html = RazorToString.RenderRazorViewToString(ControllerContext, "~/Views/Category/_ListAll.cshtml",
                       this.GetAllViewModels(), true)
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    isValid = true,
                    html = RazorToString.RenderRazorViewToString(ControllerContext, "~/Views/Category/CreateOrEdit.cshtml",
                        vm, false)
                });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var category = _categoryLogic.Get(id);

                if (category == null) return View("Error");

                var model = new CategoryViewModel()
                {
                    Id = category.CategoryID,
                    Name = category.CategoryName,
                    Description = category.Description
                };

                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(CategoryViewModel vm)
        {
            try
            {
                _categoryLogic.Delete(vm.Id);

                return Json(new
                {
                    isValid = true,
                    html = RazorToString.RenderRazorViewToString(ControllerContext, "~/Views/Category/_ListAll.cshtml",
                        this.GetAllViewModels(), true)
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    isValid = true,
                    html = RazorToString.RenderRazorViewToString(ControllerContext, "~/Views/Category/_ListAll.cshtml",
                        this.GetAllViewModels(), true)
                });
            }
        }
    }
}