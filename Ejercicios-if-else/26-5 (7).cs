namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double date;

            Console.WriteLine("Indicar una fecha como un entero de 6 dígitos");
            date = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Fecha: {date}");
            Console.WriteLine($"Mes: {Math.Truncate(Math.Truncate(date / 100) % 100)}");
        }
    }
} 