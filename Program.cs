using System;

namespace RegistroEstudiantes
{
    // Definición de la clase Estudiante
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; } // Array para almacenar los teléfonos

        // Constructor para inicializar los valores del estudiante
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Método para mostrar la información del estudiante
        public void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            foreach (var telefono in Telefonos)
            {
                Console.WriteLine(telefono); // Mostrar cada teléfono en una línea separada
            }
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main(string[] args)
        {
            // Datos del estudiante
            string[] telefonos = { "0967283141", "0992884043", "0987654321" };

            // Crear un objeto Estudiante
            Estudiante estudiante = new Estudiante(1, "Said Ramon", "Reyes Pianda", "Quevedo-La Esperanza", telefonos);

            // Mostrar la información del estudiante
            estudiante.MostrarInfo();
        }
    }
}
