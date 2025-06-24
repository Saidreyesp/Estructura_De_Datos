using System;
using System.Collections.Generic;

class Loteria
{
    public List<int> NumerosGanadores { get; set; }

    public Loteria()
    {
        // Inicializamos la lista de números ganadores
        NumerosGanadores = new List<int>();
    }

    public void PedirNumeros()
    {
        Console.WriteLine("Introduce los números ganadores de la lotería (6 números):");

        // Pedimos 6 números ganadores
        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Introduce el número #{i + 1}: ");
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1 || numero > 49)
            {
                Console.WriteLine("Por favor, introduce un número válido entre 1 y 49.");
                Console.Write($"Introduce el número #{i + 1}: ");
            }
            NumerosGanadores.Add(numero);
        }
    }

    public void MostrarNumerosOrdenados()
    {
        // Ordenamos la lista de números ganadores
        NumerosGanadores.Sort();

        Console.WriteLine("\nNúmeros ganadores ordenados de menor a mayor:");
        foreach (var numero in NumerosGanadores)
        {
            Console.WriteLine(numero);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creamos una instancia del objeto Loteria
        Loteria loteria = new Loteria();

        // Pedimos los números ganadores al usuario
        loteria.PedirNumeros();

        // Mostramos los números ordenados
        loteria.MostrarNumerosOrdenados();
    }
}
