using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab.LINQ.Logic.Base;

namespace Lab.LINQ.Logic.Product
{
    public class ProductLogic : BaseLogic
    {
        // Obtener Products sin stock -> Product.UnitsInStock == 0
        public IEnumerable<Entities.Product> GetOutOfStock()
        {
            IEnumerable<Entities.Product> products;

            //products = Context.Products.Where(p => p.UnitsInStock == 0).ToList();

            var query = from product in Context.Products
                        where product.UnitsInStock == 0
                        select product;

            products = query.ToList();

            return products;
        }

        // Obtener Products en stock con precio mayor a 3 - Product.UnitsInStock > 0 && Product.UnitPrice > 3
        public IEnumerable<Entities.Product> GetProductsInStockPriceHigherThan(decimal price)
        {
            IEnumerable<Entities.Product> products;

            //products = Context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice.Value > price).ToList();

            var query = from product in Context.Products
                        where product.UnitsInStock > 0 && product.UnitPrice.Value > price
                        select product;

            products = query.ToList();

            return products;
        }

        // Obtener Product o null con Product.ProductId == 789
        public Entities.Product GetProduct(int id)
        {
            var product = Context.Products.FirstOrDefault(p => p.ProductID == id);

            return product;
        }

        public IEnumerable<Entities.Product> GetProductsOrderByName()
        {
            IEnumerable<Entities.Product> products;

            //products = Context.Products.OrderBy(p => p.ProductName).ToList();

            var query = from product in Context.Products
                        orderby product.ProductName
                        select product;

            products = query.ToList();

            return products;
        }

        public IEnumerable<Entities.Product> GetProductsOrderByStockDesc()
        {
            var products = Context.Products.OrderByDescending(p => p.UnitsInStock).ToList();

            return products;
        }

        public IEnumerable<Entities.Product> GetProductsWithCategories()
        {
            var products = Context.Products.Include(p => p.Categories).ToList();

            return products;
        }

        public Entities.Product GetFirstProduct()
        {
            var product = Context.Products.First();

            return product;
        }
    }
}
