namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double farenheit;

            Console.WriteLine("Ingrese los grados farenheit");
            farenheit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Temperatura en celcius: {(farenheit - 32) * 5/9}");
        }
    }
} 