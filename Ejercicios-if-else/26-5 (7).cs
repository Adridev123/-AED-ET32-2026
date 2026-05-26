namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valor_hora = 13500;
            double horas_trabajadas;

            Console.WriteLine("Ingese la cantidad de horas trabajadas");
            horas_trabajadas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"El sueldo bruto es: {horas_trabajadas * valor_hora}");
        }
    }
} 
