using System;

class Program
{
    // Método estático Main, que es el punto de entrada del programa
    static void Main(string[] args)
    {
        // Pedir al usuario que ingrese una palabra
        Console.Write("Introduce una palabra: ");
        string palabra = Console.ReadLine();

        // Verificar si la palabra es un palíndromo
        if (EsPalindromo(palabra))
        {
            Console.WriteLine($"La palabra '{palabra}' es un palíndromo.");
        }
        else
        {
            Console.WriteLine($"La palabra '{palabra}' no es un palíndromo.");
        }
    }

    // Método que determina si una palabra es un palíndromo
    static bool EsPalindromo(string palabra)
    {
        // Convertir la palabra a minúsculas para que no distinga entre mayúsculas y minúsculas
        palabra = palabra.ToLower();

        // Revertir la palabra
        char[] arrayPalabra = palabra.ToCharArray();
        Array.Reverse(arrayPalabra);
        string palabraRevertida = new string(arrayPalabra);

        // Comparar la palabra original con la palabra revertida
        return palabra == palabraRevertida;
    }
}
