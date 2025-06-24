using System;
using System.Collections.Generic;

class Abecedario
{
    public List<string> Letras { get; set; }

    public Abecedario()
    {
        // Inicializamos la lista con las letras del abecedario
        Letras = new List<string>
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
    }

    public void EliminarMultiplesDeTres()
    {
        // Eliminamos las letras que ocupan posiciones múltiplos de 3
        for (int i = Letras.Count - 1; i >= 0; i--)
        {
            if ((i + 1) % 3 == 0)
            {
                Letras.RemoveAt(i);
            }
        }
    }

    public void MostrarLetras()
    {
        // Mostramos las letras restantes
        Console.WriteLine("Letras restantes del abecedario:");
        foreach (var letra in Letras)
        {
            Console.Write(letra + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creamos una instancia del objeto Abecedario
        Abecedario abecedario = new Abecedario();

        // Eliminamos las letras en posiciones múltiplos de 3
        abecedario.EliminarMultiplesDeTres();

        // Mostramos la lista resultante
        abecedario.MostrarLetras();
    }
}
