namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num;

            Console.WriteLine("Ingrese un numero de tres cifras");
            num = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Valor ingresado: {num}");
            Console.WriteLine($"Unidades: {Math.Truncate(Math.Truncate(num % 10) % 10)}");
            Console.WriteLine($"Decenas: {Math.Truncate(Math.Truncate(num / 10) % 10)}");
            Console.WriteLine($"Centenas: {Math.Truncate(num / 100)}");
        }
    }
} 