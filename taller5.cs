using System;
using System.Collections.Generic;

class ProductoEscalar
{
    // Método estático Main, que es el punto de entrada del programa
    static void Main(string[] args)
    {
        // Almacenar los vectores en dos listas
        List<int> vector1 = new List<int> { 1, 2, 3 };
        List<int> vector2 = new List<int> { -1, 0, 2 };

        // Calcular el producto escalar
        int resultado = CalcularProductoEscalar(vector1, vector2);

        // Mostrar el resultado
        Console.WriteLine("El producto escalar de los vectores es: " + resultado);
    }

    // Método para calcular el producto escalar de dos vectores
    public static int CalcularProductoEscalar(List<int> vector1, List<int> vector2)
    {
        int productoEscalar = 0;
        
        // Iterar a través de los elementos de ambos vectores y calcular la suma de los productos
        for (int i = 0; i < vector1.Count; i++)
        {
            productoEscalar += vector1[i] * vector2[i];
        }
        
        return productoEscalar;
    }
}
