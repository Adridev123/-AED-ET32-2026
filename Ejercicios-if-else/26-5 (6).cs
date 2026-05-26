namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lado;

            Console.WriteLine("Ingrese el largo del lado del cuadrado");
            lado = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"El area del cuadrado es {lado * lado} metros cuadrados");
        }
    }
} 
