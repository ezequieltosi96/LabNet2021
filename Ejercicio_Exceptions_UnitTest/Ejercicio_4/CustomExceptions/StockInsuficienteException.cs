using System;

namespace Ejercicio_4.CustomExceptions
{
    public class StockInsuficienteException : Exception
    {
        private string _message;
        public StockInsuficienteException(string message)
        {
            this._message = message;
        }

        public override string Message => _message + base.Message;
    }
}
