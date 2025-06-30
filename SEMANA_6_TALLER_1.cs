using System;
using System.Collections.Generic;

namespace Estacionamiento
{
    // Definición de la clase Vehículo
    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public double Precio { get; set; }
        
        // Constructor de la clase Vehiculo
        public Vehiculo(string placa, string marca, string modelo, int año, double precio)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Precio = precio;
        }

        // Método para mostrar la información de un vehículo
        public void MostrarInfo()
        {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Año: {Año}");
            Console.WriteLine($"Precio: {Precio}");
        }
    }

    // Definición de la clase Nodo, para la lista enlazada
    public class Nodo
    {
        public Vehiculo Vehiculo { get; set; }
        public Nodo Siguiente { get; set; }

        // Constructor del nodo
        public Nodo(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
            Siguiente = null;
        }
    }

    // Definición de la clase ListaEnlazada
    public class ListaEnlazada
    {
        private Nodo cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
        }

        // Método para agregar un vehículo a la lista
        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            Nodo nuevoNodo = new Nodo(vehiculo);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        // Método para buscar un vehículo por su placa
        public Vehiculo BuscarPorPlaca(string placa)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Vehiculo.Placa == placa)
                {
                    return actual.Vehiculo;
                }
                actual = actual.Siguiente;
            }
            return null; // Retorna null si no encuentra el vehículo
        }

        // Método para ver los vehículos por año
        public List<Vehiculo> VerPorAno(int año)
        {
            List<Vehiculo> vehiculosPorAno = new List<Vehiculo>();
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Vehiculo.Año == año)
                {
                    vehiculosPorAno.Add(actual.Vehiculo);
                }
                actual = actual.Siguiente;
            }
            return vehiculosPorAno;
        }

        // Método para ver todos los vehículos registrados
        public void VerTodos()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                actual.Vehiculo.MostrarInfo();
                Console.WriteLine("----------------------------------");
                actual = actual.Siguiente;
            }
        }

        // Método para eliminar un vehículo por su placa
        public bool EliminarPorPlaca(string placa)
        {
            if (cabeza == null) return false;

            if (cabeza.Vehiculo.Placa == placa)
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Vehiculo.Placa == placa)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false; // Retorna false si no se encuentra el vehículo
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada listaDeVehiculos = new ListaEnlazada();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar vehículo");
                Console.WriteLine("2. Buscar vehículo por placa");
                Console.WriteLine("3. Ver vehículos por año");
                Console.WriteLine("4. Ver todos los vehículos registrados");
                Console.WriteLine("5. Eliminar vehículo por placa");
                Console.WriteLine("6. Salir");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese los datos del vehículo:");

                        Console.Write("Placa: ");
                        string placa = Console.ReadLine();

                        Console.Write("Marca: ");
                        string marca = Console.ReadLine();

                        Console.Write("Modelo: ");
                        string modelo = Console.ReadLine();

                        Console.Write("Año: ");
                        int año = int.Parse(Console.ReadLine());

                        Console.Write("Precio: ");
                        double precio = double.Parse(Console.ReadLine());

                        Vehiculo nuevoVehiculo = new Vehiculo(placa, marca, modelo, año, precio);
                        listaDeVehiculos.AgregarVehiculo(nuevoVehiculo);
                        Console.WriteLine("Vehículo agregado exitosamente.");
                        break;

                    case "2":
                        Console.Write("Ingrese la placa del vehículo a buscar: ");
                        string placaBuscar = Console.ReadLine();
                        Vehiculo vehiculoEncontrado = listaDeVehiculos.BuscarPorPlaca(placaBuscar);
                        if (vehiculoEncontrado != null)
                        {
                            vehiculoEncontrado.MostrarInfo();
                        }
                        else
                        {
                            Console.WriteLine("Vehículo no encontrado.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese el año para buscar vehículos: ");
                        int añoBuscar = int.Parse(Console.ReadLine());
                        List<Vehiculo> vehiculosPorAno = listaDeVehiculos.VerPorAno(añoBuscar);
                        if (vehiculosPorAno.Count > 0)
                        {
                            foreach (var vehiculo in vehiculosPorAno)
                            {
                                vehiculo.MostrarInfo();
                                Console.WriteLine("----------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron vehículos de ese año.");
                        }
                        break;

                    case "4":
                        listaDeVehiculos.VerTodos();
                        break;

                    case "5":
                        Console.Write("Ingrese la placa del vehículo a eliminar: ");
                        string placaEliminar = Console.ReadLine();
                        bool eliminado = listaDeVehiculos.EliminarPorPlaca(placaEliminar);
                        if (eliminado)
                        {
                            Console.WriteLine("Vehículo eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un vehículo con esa placa.");
                        }
                        break;

                    case "6":
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
