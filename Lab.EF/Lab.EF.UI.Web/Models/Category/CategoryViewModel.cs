using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab.EF.UI.Web.Models.Base;

namespace Lab.EF.UI.Web.Models.Category
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}