namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num;

            Console.WriteLine("Ingrese un numero de dos cifras");
            num = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"El numero de decenas es: {Math.Truncate(num / 10)}");
            Console.WriteLine($"El numero de unidades es: {Math.Truncate(num % 10)}");
        }
    }
} 