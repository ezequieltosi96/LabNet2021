using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Lab.EF.Entities;
using Lab.EF.Logic.Category;
using Lab.EF.UI.WebApi.Models.Category;

namespace Lab.EF.UI.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        private readonly CategoryLogic _categoryLogic;

        public CategoryController()
        {
            _categoryLogic = new CategoryLogic();
        }

        public IEnumerable<CategoryViewModel> Get(string searchString = "")
        {
            if (searchString == null) searchString = "";
            var categories = _categoryLogic.GetAll(searchString).Select(c => new CategoryViewModel()
            {
                Id = c.CategoryID,
                Name = c.CategoryName,
                Description = c.Description
            }).ToList();

            return categories;
        }

        public CategoryViewModel Get(int id)
        {
            var category = _categoryLogic.Get(id);

            if (category == null) return null;

            var categoryModel = new CategoryViewModel()
            {
                Id = category.CategoryID,
                Name = category.CategoryName,
                Description = category.Description
            };

            return categoryModel;
        }

        public IHttpActionResult Post(CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de validación.");
            }

            try
            {
                _categoryLogic.Add(new Category()
                {
                    CategoryName = vm.Name,
                    Description = vm.Description
                });

                return Ok(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de validación.");
            }

            try
            {
                _categoryLogic.Update(new Category()
                {
                    CategoryID = vm.Id,
                    CategoryName = vm.Name,
                    Description = vm.Description
                });

                return Ok(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var category = _categoryLogic.Get(id);

                if (category == null) return NotFound();

                _categoryLogic.Delete(id);

                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
