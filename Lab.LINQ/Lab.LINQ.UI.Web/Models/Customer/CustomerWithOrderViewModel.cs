using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.LINQ.UI.Web.Models.Customer
{
    public class CustomerWithOrderViewModel
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string Region { get; set; }
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
    }
}