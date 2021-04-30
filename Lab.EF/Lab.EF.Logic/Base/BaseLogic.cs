using System;
using System.Collections.Generic;
using System.Linq;
using Lab.EF.Data;
using Lab.EF.ILogic;

namespace Lab.EF.Logic.Base
{
    public class BaseLogic
    {
        protected NorthwindContext Context;

        public BaseLogic()
        {
            Context = new NorthwindContext();
        }
    }
}
