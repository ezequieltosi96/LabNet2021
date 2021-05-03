using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.LINQ.Data;

namespace Lab.LINQ.Logic.Base
{
    public class BaseLogic
    {
        protected readonly NorthwindContext Context;

        public BaseLogic()
        {
            Context = new NorthwindContext();
        }
    }
}
