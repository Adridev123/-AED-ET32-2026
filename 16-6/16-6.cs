using System.Runtime.CompilerServices;

static void Ejercicio1()
{
    string palabra;

    Console.WriteLine("Ingrese una palabra");
    palabra = Console.ReadLine();
    Console.WriteLine($"El numero de caracteres de la cadena es: {palabra.Length}");
}


static void Ejercicio2()
{
    string palabra;

    Console.WriteLine("Ingrese una palabra");
    palabra = Console.ReadLine();
    Console.WriteLine($"Palabra en mayusculas: {palabra.ToUpper()}");
    Console.WriteLine($"Palabra en minusculas: {palabra.ToLower()}");
    Console.WriteLine($"El numero de caracteres de la cadena es: {palabra.Length}");
}


static void Ejercicio3()
{
    string frase;
    int count = 0;

    Console.WriteLine("Ingrese una frase");
    frase = Console.ReadLine().ToLower();
    for (int i = 0; i < frase.Length; i++)
    {
        if("aeiou".Contains(frase[i]))
        {
            count++;
        }
    }
    Console.WriteLine($"La cantidad de vocales en la frase es: {count}");
}


static void Ejercicio4() // No vimos este tema profe, igual si lo entendi
{
    try
    {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine() ?? ""; // por si se pone algo null

        Console.WriteLine($"Primera letra: {palabra[0]}");
        Console.WriteLine($"Última letra: {palabra[palabra.Length - 1]}");
    }
    catch (IndexOutOfRangeException) // en caso de que no supongo
    {
        Console.WriteLine("Error: la cadena está vacía.");
    }
}


static void Ejercicio5()
{
    try
    {
        int num1, num2;

        Console.Write("Ingrese el primer número: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Resultado: {num1 / num2}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: debe ingresar números enteros válidos.");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Error: no se puede dividir por cero.");
    }
}


static void Ejercicio6()
{
    try
    {
        string palabra;
        int posicion;

        Console.Write("Ingrese una palabra: ");
        palabra = Console.ReadLine() ?? "";

        Console.Write("Ingrese una posición: ");
        posicion = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Carácter: {palabra[posicion]}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: debe ingresar un número válido.");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Error: la posición está fuera de rango.");
    }
}


static void Ejercicio7()
{
    string palabra;
    string frase;

    Console.WriteLine("Ingrese una palabra");
    palabra = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese una frase");
    frase = Console.ReadLine() ?? "";

    if (frase.Contains(palabra))
    {
        Console.WriteLine("La palabra si se encuentra en la frase");
    }
    else
    {
        Console.WriteLine("La palabra no se encuentra en la frase");
    }
}


static void Ejercicio8()
{
    try
    {
        Console.Write("Ingrese números separados por comas: ");
        string cadena = Console.ReadLine() ?? "";

        string[] numeros = cadena.Split(',');
        int suma = 0;

        foreach (string numero in numeros)
        {
            suma += int.Parse(numero);
        }

        Console.WriteLine($"La suma es: {suma}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: uno o más valores no son números válidos.");
    }
}


static void Ejercicio9()
{
    string palabra;

    Console.Write("Ingrese una palabra: ");
    palabra = Console.ReadLine() ?? "";
    Console.WriteLine($"Palabra invertida: {palabra.Reverse()}");
}


static void Ejercicio10()
{
    try
    {
        Console.Write("Ingrese una contraseña: ");
        string contraseña = Console.ReadLine() ?? "";

        if (contraseña.Length < 8)
        {
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
        }

        bool tieneNumero = false;

        foreach (char c in contraseña)
        {
            if (char.IsDigit(c))
            {
                tieneNumero = true;
                break;
            }
        }

        if (!tieneNumero)
        {
            throw new ArgumentException("La contraseña debe contener al menos un número.");
        }

        Console.WriteLine("Contraseña válida.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


static void Ejercicio11()
{
    try
    {
        Console.Write("Ingrese una edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());

        if (edad < 1 || edad > 120)
        {
            throw new ArgumentOutOfRangeException("edad", "La edad debe estar entre 1 y 120.");
        }

        Console.WriteLine("Edad válida.");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: debe ingresar un número entero.");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


static void Ejercicio12()
{
    try
    {
        string texto = null;

        Console.WriteLine(texto.Length);
    }
    catch (NullReferenceException)
    {
        Console.WriteLine("Error: se intentó acceder a una referencia nula.");
    }
}


static void Ejercicio13()
{
    try
    {
        int num1, num2, suma;

        Console.Write("Ingrese el primer número: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        checked
        {
            suma = num1 + num2;
        }

        Console.WriteLine($"La suma es: {suma}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: debe ingresar números válidos.");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Error: la suma excede el rango permitido para un entero.");
    }
}


static void Ejercicio14()
{
    try
    {
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine() ?? "";

        if (frase.Length == 0)
        {
            throw new ArgumentException("La frase no puede estar vacía.");
        }

        Console.WriteLine($"Cantidad de caracteres: {frase.Length}");

        string[] palabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"Cantidad de palabras: {palabras.Length}");

        int vocales = 0;
        foreach (char letra in frase.ToLower())
        {
            if ("aeiou".Contains(letra))
            {
                vocales++;
            }
        }
        Console.WriteLine($"Cantidad de vocales: {vocales}");

        Console.Write("Ingrese una posición: ");
        int posicion = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Carácter: {frase[posicion]}");

        Console.Write("Ingrese un número: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"100 / {numero} = {100 / numero}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: formato de número inválido.");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Error: la posición está fuera de rango.");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Error: no se puede dividir por cero.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


int opcion;


do
{
    Console.WriteLine("\n==Menu==");
    Console.WriteLine("1: Ejercicio1");
    Console.WriteLine("2: Ejercicio2");
    Console.WriteLine("3: Ejercicio3");
    Console.WriteLine("4: Ejercicio4");
    Console.WriteLine("5: Ejercicio5");
    Console.WriteLine("6: Ejercicio6");
    Console.WriteLine("7: Ejercicio7");
    Console.WriteLine("8: Ejercicio8");
    Console.WriteLine("9: Ejercicio9");
    Console.WriteLine("10: Ejercicio10");
    Console.WriteLine("11: Ejercicio11");
    Console.WriteLine("12: Ejercicio12");
    Console.WriteLine("13: Ejercicio13");
    Console.WriteLine("14: Ejercicio14");
    Console.WriteLine("0: Salir");

    opcion = Convert.ToInt16(Console.ReadLine());

    switch (opcion)
    {
        case 1: Ejercicio1(); break;
        case 2: Ejercicio2(); break;
        case 3: Ejercicio3(); break;
        case 4: Ejercicio4(); break;
        case 5: Ejercicio5(); break;
        case 6: Ejercicio6(); break;
        case 7: Ejercicio7(); break;
        case 8: Ejercicio8(); break;
        case 9: Ejercicio9(); break;
        case 10: Ejercicio10(); break;
        case 11: Ejercicio11(); break;
        case 12: Ejercicio12(); break;
        case 13: Ejercicio13(); break;
        case 14: Ejercicio14(); break;
        case 0: Console.WriteLine("Adios"); break;
    }
} while (opcion != 0);
