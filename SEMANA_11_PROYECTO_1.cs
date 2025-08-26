using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario que contiene las palabras y sus equivalencias
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"Time", "tiempo"},
        {"Person", "persona"},
        {"Year", "año"},
        {"Way", "camino"},
        {"Day", "día"},
        {"Thing", "cosa"},
        {"Man", "hombre"},
        {"World", "mundo"},
        {"Life", "vida"},
        {"Hand", "mano"},
        {"Part", "parte"},
        {"Child", "niño"},
        {"Eye", "ojo"},
        {"Woman", "mujer"},
        {"Place", "lugar"},
        {"Work", "trabajo"},
        {"Week", "semana"},
        {"Case", "caso"},
        {"Point", "punto"},
        {"Government", "gobierno"},
        {"Company", "empresa"}
    };

    static void Main()
    {
        int opcion;
        
        do
        {
            // Mostrar menú
            Console.Clear();
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Seleccione una opción:");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;

                case 2:
                    AgregarPalabra();
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        } while (opcion != 0);
    }

    // Método para traducir una frase
    static void TraducirFrase()
    {
        Console.WriteLine("Frase ingresada: ");
        string frase = Console.ReadLine();

        // Dividir la frase en palabras
        string[] palabras = frase.Split(' ');
        List<string> traduccion = new List<string>();

        foreach (var palabra in palabras)
        {
            // Verificar si la palabra está en el diccionario
            if (diccionario.ContainsKey(palabra))
            {
                traduccion.Add(diccionario[palabra]);
            }
            else
            {
                traduccion.Add(palabra);  // Si no está, dejamos la palabra original
            }
        }

        // Mostrar la traducción
        Console.WriteLine("Traducción:");
        Console.WriteLine(string.Join(" ", traduccion));
    }

    // Método para agregar una nueva palabra al diccionario
    static void AgregarPalabra()
    {
        Console.WriteLine("Ingrese la palabra en inglés:");
        string palabraIngles = Console.ReadLine();

        Console.WriteLine("Ingrese la traducción al español:");
        string palabraEspanol = Console.ReadLine();

        // Agregar la palabra al diccionario si no existe
        if (!diccionario.ContainsKey(palabraIngles))
        {
            diccionario.Add(palabraIngles, palabraEspanol);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
