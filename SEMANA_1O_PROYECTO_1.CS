using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Generación de datos ficticios
        var todosLosCiudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todosLosCiudadanos.Add($"Ciudadano {i}");
        }

        // Ciudadanos vacunados con Pfizer y AstraZeneca
        var vacunadosPfizer = new HashSet<string>();
        var vacunadosAstraZeneca = new HashSet<string>();

        // Asignamos aleatoriamente 75 ciudadanos para cada vacuna
        Random random = new Random();
        while (vacunadosPfizer.Count < 75)
        {
            vacunadosPfizer.Add($"Ciudadano {random.Next(1, 501)}");
        }
        
        while (vacunadosAstraZeneca.Count < 75)
        {
            vacunadosAstraZeneca.Add($"Ciudadano {random.Next(1, 501)}");
        }

        // Ciudadanos no vacunados
        var noVacunados = new HashSet<string>(todosLosCiudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos que han recibido ambas dosis
        var ambasDosis = new HashSet<string>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstraZeneca);

        // Ciudadanos solo vacunados con Pfizer
        var soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos solo vacunados con AstraZeneca
        var soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        // Mostrar los resultados
        Console.WriteLine("Ciudadanos no vacunados:");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\nCiudadanos que han recibido ambas dosis:");
        foreach (var ciudadano in ambasDosis)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\nCiudadanos solo vacunados con Pfizer:");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano);
        }

        Console.WriteLine("\nCiudadanos solo vacunados con AstraZeneca:");
        foreach (var ciudadano in soloAstraZeneca)
        {
            Console.WriteLine(ciudadano);
        }
    }
}
