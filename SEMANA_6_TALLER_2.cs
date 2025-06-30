using System;

namespace RegistroEstudiantesRedesIII
{
    public class Estudiante
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; } // "Aprobado" o "Reprobado"
        
        public Estudiante(string cedula, string nombre, string estado)
        {
            Cedula = cedula;
            Nombre = nombre;
            Estado = estado;
        }
    }

    public class Nodo
    {
        public Estudiante Estudiante;
        public Nodo Siguiente;
        public Nodo(Estudiante estudiante) => (Estudiante, Siguiente) = (estudiante, null);
    }

    public class ListaEnlazada
    {
        private Nodo cabeza;

        public void AgregarEstudiante(Estudiante estudiante)
        {
            Nodo nuevoNodo = new Nodo(estudiante);

            if (estudiante.Estado == "Aprobado")
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza = nuevoNodo;
            }
            else
            {
                if (cabeza == null)
                    cabeza = nuevoNodo;
                else
                {
                    Nodo actual = cabeza;
                    while (actual.Siguiente != null) actual = actual.Siguiente;
                    actual.Siguiente = nuevoNodo;
                }
            }
        }

        public Estudiante BuscarPorCedula(string cedula)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Estudiante.Cedula == cedula) return actual.Estudiante;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool EliminarPorCedula(string cedula)
        {
            if (cabeza == null) return false;

            if (cabeza.Estudiante.Cedula == cedula)
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Estudiante.Cedula == cedula)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public int TotalEstudiantes(string estado)
        {
            int count = 0;
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Estudiante.Estado == estado) count++;
                actual = actual.Siguiente;
            }
            return count;
        }

        public void MostrarTodos()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"Cédula: {actual.Estudiante.Cedula}, Nombre: {actual.Estudiante.Nombre}, Estado: {actual.Estudiante.Estado}");
                actual = actual.Siguiente;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ListaEnlazada lista = new ListaEnlazada();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Buscar estudiante por cédula");
                Console.WriteLine("3. Eliminar estudiante");
                Console.WriteLine("4. Total estudiantes aprobados");
                Console.WriteLine("5. Total estudiantes reprobados");
                Console.WriteLine("6. Ver todos los estudiantes");
                Console.WriteLine("7. Salir");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Cédula: ");
                        var cedula = Console.ReadLine();
                        Console.Write("Nombre: ");
                        var nombre = Console.ReadLine();
                        Console.Write("Estado (Aprobado/Reprobado): ");
                        var estado = Console.ReadLine();
                        lista.AgregarEstudiante(new Estudiante(cedula, nombre, estado));
                        break;

                    case "2":
                        Console.Write("Cédula: ");
                        var cedulaBuscar = Console.ReadLine();
                        var estudiante = lista.BuscarPorCedula(cedulaBuscar);
                        if (estudiante != null)
                            Console.WriteLine($"Estudiante encontrado: {estudiante.Nombre}, Estado: {estudiante.Estado}");
                        else
                            Console.WriteLine("Estudiante no encontrado.");
                        break;

                    case "3":
                        Console.Write("Cédula: ");
                        var cedulaEliminar = Console.ReadLine();
                        if (lista.EliminarPorCedula(cedulaEliminar))
                            Console.WriteLine("Estudiante eliminado.");
                        else
                            Console.WriteLine("Estudiante no encontrado.");
                        break;

                    case "4":
                        Console.WriteLine($"Total Aprobados: {lista.TotalEstudiantes("Aprobado")}");
                        break;

                    case "5":
                        Console.WriteLine($"Total Reprobados: {lista.TotalEstudiantes("Reprobado")}");
                        break;

                    case "6":
                        lista.MostrarTodos();
                        break;

                    case "7":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
