using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab.EF.Entities;
using Lab.EF.Logic.Supplier;
using Lab.EF.UI.WebApi.Models.Supplier;

namespace Lab.EF.UI.WebApi.Controllers
{
    public class SupplierController : ApiController
    {
        private readonly SupplierLogic _supplierLogic;

        public SupplierController()
        {
            _supplierLogic = new SupplierLogic();
        }

        public IEnumerable<SupplierViewModel> Get()
        {
            var suppliers = _supplierLogic.GetAll().Select(s => new SupplierViewModel()
            {
                Id = s.SupplierID,
                Address = s.Address,
                City = s.City,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                Country = s.Country,
                Fax = s.Fax,
                HomePage = s.HomePage,
                Phone = s.Phone,
                PostalCode = s.PostalCode,
                Region = s.Region
            }).ToList();

            return suppliers;
        }

        public SupplierViewModel Get(int id)
        {
            var supplier = _supplierLogic.Get(id);

            if (supplier == null) return null;

            var supplierModel = new SupplierViewModel()
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

            return supplierModel;
        }

        public IHttpActionResult Post(SupplierViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de validación.");
            }

            try
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

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(SupplierViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error de validación.");
            }

            try
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

                return Ok();
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
                var supplier = _supplierLogic.Get(id);

                if (supplier == null) return NotFound();

                _supplierLogic.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
