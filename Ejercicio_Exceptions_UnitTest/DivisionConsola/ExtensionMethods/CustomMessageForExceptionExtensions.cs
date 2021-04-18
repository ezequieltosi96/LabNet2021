using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionConsola.ExtensionMethods
{
    public static class CustomMessageForExceptionExtensions
    {
        public static string CustomMessage(this Exception ex, string mensaje)
        {
            return $"{mensaje} --- {ex.Message}";
        }
    }
}
