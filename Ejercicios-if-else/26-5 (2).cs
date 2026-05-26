using System.Globalization;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num;

            Console.WriteLine("Ingrese un numero de tres cifras");
            num = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine($"Valor: {num}");
            Console.WriteLine($"Cifra central: {Math.Truncate(Math.Truncate(num / 10) % 10)}");
        }
    }
} 