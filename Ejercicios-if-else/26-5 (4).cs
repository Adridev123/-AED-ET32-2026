namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num;
            double num_1;
            double num_2;

            Console.WriteLine("Ingrese un numero de dos cifras");
            num = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Valor: {num}");
            num_1 = Math.Truncate(num / 10);
            num_2 = Math.Truncate(num % 10);
            Console.WriteLine($"Valor permutado: {num_2}{num_1}");
        }
    }
} 