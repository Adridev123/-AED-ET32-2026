string palabra;
string letra;
int count = 0;

Console.WriteLine("Ingrese una palabra");
palabra = Console.ReadLine() ?? "";

Console.WriteLine("Ingrese una letra");
letra = Console.ReadLine() ?? "";

for (int i = 0; i < palabra.Length; i++)
{
    if (palabra[i].ToString() == letra)
    {
        count++;
    }
}

Console.WriteLine($"El numero de veces que aparece la letra en la palabra es {count}");