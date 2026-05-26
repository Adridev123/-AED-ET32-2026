namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double horas;
            double minutos;
            double segundos;
            double total1;
            double total2;

            Console.WriteLine("Ingrese la cantidad de horas del instante 1");
            horas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de minutos del instante 1");
            minutos = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de segundos del instante 1");
            segundos = Convert.ToDouble(Console.ReadLine());

            total1 = (horas * 3600) + (minutos * 60) + segundos;

            Console.WriteLine("Ingrese la cantidad de horas del instante 2");
            horas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de minutos del instante 2");
            minutos = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de segundos del instante 2");
            segundos = Convert.ToDouble(Console.ReadLine());

            total2 = (horas * 3600) + (minutos * 60) + segundos;

            if (total2 > total1)
            {
                Console.WriteLine($"La diferencia de segundos entre ambos es: {total2 - total1}");
            }
            else
            {
                Console.WriteLine($"La diferencia de segundos entre ambos es: {total1 - total2}");
            }
            // (tambien se puede poner math.abs q es el valor absoluto, o sea q si es negativo simplemente saca el menos y me ahorro el if/else)
        }
    }
} 