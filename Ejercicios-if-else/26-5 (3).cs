using System.Globalization;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double precio;

            Console.WriteLine($"Indicar el precio de la lista");
            precio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Precio de lista: {precio}");
            Console.WriteLine("Descuento: 18% sobre el precio de lista.");
            Console.WriteLine($"Precio con descuento: {(precio / 100) * 18}");
        }
    }
} 