using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lab.EF.UI.MVC.Models.Base;

namespace Lab.EF.UI.MVC.Models.Supplier
{
    public class SupplierListViewModel : BaseViewModel
    {
        [DisplayName("Company")]
        public string CompanyName { get; set; }

        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}