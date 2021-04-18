using System;
using Ejercicio_4;
using Ejercicio_4.CustomExceptions;

namespace Ejercicio_4_Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("De un stock disponible de 30 unidades se intentara restar 31 unidades. Esta vez obtendremos una excepcion personalizada.");
                var controlStock = new Logic(30);
                var stockADisminuir = 31;

                var result = controlStock.DisminuirStock(stockADisminuir);
            }
            catch (StockInsuficienteException ex)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Tipo de excepcion arrojada: {ex.GetType()}");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Excepcion:");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}
