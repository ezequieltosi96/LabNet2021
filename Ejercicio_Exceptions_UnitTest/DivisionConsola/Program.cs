using System;
using DivisionConsola.Servicios;

namespace DivisionConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var divisionServicio = new DivisionServicio();

            try
            {
                Console.WriteLine("1) División por cero: ");
                Console.WriteLine(Environment.NewLine);
                divisionServicio.DivideByZero(10m);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Fin del metodo 'DivideByZero'.");
            }

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Ahora que sabes que no se puede dividir por cero....");
            Console.WriteLine(Environment.NewLine);

            try
            {
                Console.Write("2) División - 3 / 0: ");
                var resultado = divisionServicio.Divide(3, 0);
                Console.Write(resultado);
                Console.WriteLine(Environment.NewLine);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Mensaje: {ex.Message}");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Fin del metodo 'Divide'.");
            }

            Console.ReadKey();
        }
    }
}
