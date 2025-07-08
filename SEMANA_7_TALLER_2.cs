using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Método recursivo para resolver el problema de las Torres de Hanoi
    public static void ResolverTorres(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string torreOrigen, string torreDestino, string torreAuxiliar)
    {
        // Caso base: Si solo queda un disco, moverlo directamente
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {torreOrigen} a {torreDestino}");
            return;
        }

        // Mover n-1 discos de la torre origen a la torre auxiliar usando la torre destino como auxiliar
        ResolverTorres(n - 1, origen, auxiliar, destino, torreOrigen, torreAuxiliar, torreDestino);

        // Mover el disco restante a la torre destino
        int discoFinal = origen.Pop();
        destino.Push(discoFinal);
        Console.WriteLine($"Mover disco {discoFinal} de {torreOrigen} a {torreDestino}");

        // Mover los n-1 discos de la torre auxiliar a la torre destino usando la torre origen como auxiliar
        ResolverTorres(n - 1, auxiliar, destino, origen, torreAuxiliar, torreDestino, torreOrigen);
    }

    static void Main()
    {
        // Número de discos
        int n = 3;

        // Inicialización de las pilas para las tres torres
        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        // Colocamos los discos en la torre A (torre de origen)
        for (int i = n; i >= 1; i--)
        {
            torreA.Push(i);
        }

        // Mostrar el estado inicial
        Console.WriteLine("Estado inicial:");
        Console.WriteLine("Torre A: " + string.Join(", ", torreA));
        Console.WriteLine("Torre B: " + string.Join(", ", torreB));
        Console.WriteLine("Torre C: " + string.Join(", ", torreC));

        // Llamada al método para resolver las Torres de Hanoi
        ResolverTorres(n, torreA, torreC, torreB, "A", "C", "B");

        // Mostrar el estado final
        Console.WriteLine("\nEstado final:");
        Console.WriteLine("Torre A: " + string.Join(", ", torreA));
        Console.WriteLine("Torre B: " + string.Join(", ", torreB));
        Console.WriteLine("Torre C: " + string.Join(", ", torreC));
    }
}
