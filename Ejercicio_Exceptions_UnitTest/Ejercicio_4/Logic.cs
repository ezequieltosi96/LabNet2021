using Ejercicio_4.CustomExceptions;

namespace Ejercicio_4
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
                throw new StockInsuficienteException("Stock insuficiente.");
            }

            _stock -= cantidad;

            return _stock;
        }
    }
}
