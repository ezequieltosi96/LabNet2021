using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    public class Logic
    {
        private int _stock;

        public Logic(int stock)
        {
            this._stock = stock;
        }

        public int DisminuirStock(int cantidad)
        {
            if (cantidad > _stock)
            {
                throw new Exception("Stock insuficiente.");
            }

            _stock -= cantidad;

            return _stock;
        }
    }
}
