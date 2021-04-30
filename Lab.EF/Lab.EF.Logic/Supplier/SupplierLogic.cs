using System.Collections.Generic;
using System.Linq;
using Lab.EF.ILogic;
using Lab.EF.Logic.Base;

namespace Lab.EF.Logic.Supplier
{
    public class SupplierLogic : BaseLogic, IBaseLogic<Entities.Supplier>
    {
        public void Add(Entities.Supplier newEntity)
        {
            Context.Suppliers.Add(newEntity);
            Context.SaveChanges();
        }

        public void Update(Entities.Supplier entity)
        {
            var supplier = Context.Suppliers.FirstOrDefault(s => s.SupplierID == entity.SupplierID);

            if (supplier != null)
            {
                supplier.Address = entity.Address;
                supplier.City = entity.City;
                supplier.CompanyName = entity.CompanyName;
                supplier.ContactName = entity.ContactName;
                supplier.ContactTitle = entity.ContactTitle;
                supplier.Country = entity.Country;
                supplier.Fax = entity.Fax;
                supplier.HomePage = entity.HomePage;
                supplier.Phone = entity.Phone;
                supplier.PostalCode = entity.PostalCode;
                supplier.Region = entity.Region;

                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var supplier = Context.Suppliers.FirstOrDefault(s => s.SupplierID == id);

            if (supplier != null)
            {
                Context.Suppliers.Remove(supplier);
                Context.SaveChanges();
            }
        }

        public Entities.Supplier Get(int id)
        {
            var supplier = Context.Suppliers.FirstOrDefault(s => s.SupplierID == id);

            return supplier;
        }

        public IEnumerable<Entities.Supplier> GetAll()
        {
            var suppliers = Context.Suppliers.ToList();

            return suppliers;
        }
    }
}
