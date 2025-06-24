using System;
using System.Collections.Generic;

class Curso
{
    public List<string> Asignaturas { get; set; }

    public Curso()
    {
        // Inicializamos la lista con las asignaturas
        Asignaturas = new List<string> { "Metodologia de la investigacion", "Estructura de datos", "Fundamentos digitales", "Administracion de sistemas operativos", "Istalaciones electricas" };
    }

    public void MostrarAsignaturas()
    {
        // Mostramos las asignaturas por pantalla
        Console.WriteLine("Asignaturas del curso:");
        foreach (var asignatura in Asignaturas)
        {
            Console.WriteLine(asignatura);
        }
    }
}

class CursoProgram
{
    static void Main(string[] args)
    {
        // Creamos una instancia del objeto Curso
        Curso curso = new Curso();

        // Mostramos las asignaturas
        curso.MostrarAsignaturas();
    }
}
