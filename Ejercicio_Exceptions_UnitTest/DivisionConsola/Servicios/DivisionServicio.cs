using System;
using DivisionConsola.ExtensionMethods;

namespace DivisionConsola.Servicios
{
    public class DivisionServicio
    {
        public void DivideByZero(decimal value)
        {
            try
            {
                var result = value / Decimal.Zero;
            }
            catch (DivideByZeroException ex)
            {
                throw new DivideByZeroException(ex.CustomMessage("En matemática, la división por cero no esta definida."));
            }
        }

        public decimal? Divide(decimal? dividend, decimal? divider)
        {
            try
            {
                var result = dividend.Value / divider.Value;
                return result;
            }
            catch (DivideByZeroException ex)
            {
                throw new DivideByZeroException(ex.CustomMessage("Solo Chuck Norris puede dividir por cero!"));
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.CustomMessage("Seguro ingresó una letra ó no ingresó nada!"));
            }
        }
    }
}
