using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_3;

namespace Ejercicio_3_Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("De un stock disponible de 30 unidades se intentara restar 31 unidades.");
                var controlStock = new Logic(30);
                var stockADisminuir = 31;

                var result = controlStock.DisminuirStock(stockADisminuir);
            }
            catch (Exception ex)
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
