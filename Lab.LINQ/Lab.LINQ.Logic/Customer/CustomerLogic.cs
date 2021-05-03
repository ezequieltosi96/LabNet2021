using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab.LINQ.Logic.Base;
using Lab.LINQ.Logic.Customer.Dto;

namespace Lab.LINQ.Logic.Customer
{
    public class CustomerLogic : BaseLogic
    {
        // Obtener un Customer
        public Entities.Customer GetCustomer(string id)
        {
            var query = from customer in Context.Customers
                        where customer.CustomerID.Equals(id)
                        select customer;

            var custom = query.FirstOrDefault();

            return custom;
        }

        // Obtener todos los Customer de WA
        public IEnumerable<Entities.Customer> GetWashingtonCustomers()
        {
            var customers = Context.Customers.Where(c => c.Region.Equals("WA")).ToList();

            return customers;
        }

        // Obtener Customer.ContactName - Mayusculas y minisculas
        private IEnumerable<string> GetCustomersNames()
        {
            IEnumerable<string> customersNames;

            //customersNames = Context.Customers.Select(c => c.ContactName).ToList();

            var query = from customer in Context.Customers
                        select customer.ContactName;

            customersNames = query.ToList();

            return customersNames;
        }

        public IEnumerable<string> GetCustomersNamesUpper()
        {
            var customersNames = GetCustomersNames();
            var customersNamesUpper = customersNames.Select(cn => cn.ToUpper());

            return customersNamesUpper;
        }

        public IEnumerable<string> GetCustomersNamesLower()
        {
            var customersNames = GetCustomersNames();
            var customersNamesLower = customersNames.Select(cn => cn.ToLower());

            return customersNamesLower;
        }

        // Obtener Customers de WA con Order.OrderDate > 01/01/1997
        public IEnumerable<CustomerWithOrderDto> GetWashingtonCustomersWithOrderDateGreaterThan(DateTime date)
        {
            var query = from customer in Context.Customers
                        join order in Context.Orders on customer equals order.Customers
                        where (order.OrderDate.HasValue && order.OrderDate.Value.CompareTo(date) == 1) &&
                              customer.Region.Equals("WA")
                        select new CustomerWithOrderDto()
                        {
                            CustomerID = customer.CustomerID,
                            ContactName = customer.ContactName,
                            Region = customer.Region,
                            OrderID = order.OrderID,
                            OrderDate = order.OrderDate.Value
                        };

            var customers = query.ToList();

            return customers;
        }

        // Obtener 3 primeros Customer de WA
        public IEnumerable<Entities.Customer> GetFirstThreeWashingtonCustomers()
        {
            var customers = Context.Customers.Where(c => c.Region.Equals("WA")).Take(3).ToList();

            return customers;
        }

        // Obtener Customer con cantidad de Orders
        public IEnumerable<CustomerWithOrderQttyDto> GetCustomersWithOrdersQtty()
        {
            var customers = Context.Customers
                            .Include(c => c.Orders)
                            .Select(c => new CustomerWithOrderQttyDto()
                            {
                                CustomerID = c.CustomerID,
                                ContactName = c.ContactName,
                                OrdersQty = c.Orders.Count
                            }).ToList();

            return customers;
        }
    }
}
