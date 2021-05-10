using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lab.EF.UI.WebApi.Models.Base;

namespace Lab.EF.UI.WebApi.Models.Category
{
    public class CategoryViewModel : BaseViewModel
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(length: 15, ErrorMessage = "{0} have a maximum of {1} characters.")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}