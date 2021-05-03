using System;

namespace Lab.LINQ.Logic.Customer.Dto
{
    public class CustomerWithOrderDto
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string Region { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
