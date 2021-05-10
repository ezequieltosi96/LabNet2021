using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lab.EF.UI.WebApi.Models.Base;

namespace Lab.EF.UI.WebApi.Models.Supplier
{
    public class SupplierViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(40, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("Company")]
        public string CompanyName { get; set; }

        [MaxLength(30, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [MaxLength(30, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("Contact Title")]
        public string ContactTitle { get; set; }

        [MaxLength(60, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [MaxLength(15, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("City")]
        public string City { get; set; }

        [MaxLength(15, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("Region")]
        public string Region { get; set; }

        [MaxLength(10, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("ZIP Code")]
        public string PostalCode { get; set; }

        [MaxLength(15, ErrorMessage = "{0} have a maximum of {1} characters.")]
        public string Country { get; set; }

        [MaxLength(24, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("Phone")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }

        [MaxLength(24, ErrorMessage = "{0} have a maximum of {1} characters.")]
        [DisplayName("Fax")]
        public string Fax { get; set; }

        [DisplayName("Web Site")]
        public string HomePage { get; set; }
    }
}