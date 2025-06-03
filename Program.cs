using System;

// Clase para representar un Círculo
public class Circulo
{
    // Radio del círculo (encapsulado como propiedad)
    public double Radio { get; set; }

    // Constructor de la clase Circulo
    public Circulo(double radio)
    {
        Radio = radio;
    }

    // CalcularArea devuelve el área del círculo usando la fórmula π * r²
    public double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }

    // CalcularPerimetro devuelve la circunferencia (perímetro) usando 2 * π * r
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * Radio;
    }
}

// Clase para representar un Rectángulo
public class Rectangulo
{
    // Propiedades encapsuladas: Largo y Ancho
    public double Largo { get; set; }
    public double Ancho { get; set; }

    // Constructor de la clase Rectangulo
    public Rectangulo(double largo, double ancho)
    {
        Largo = largo;
        Ancho = ancho;
    }

    // CalcularArea devuelve el área del rectángulo (Largo * Ancho)
    public double CalcularArea()
    {
        return Largo * Ancho;
    }

    // CalcularPerimetro devuelve el perímetro del rectángulo (2 * (Largo + Ancho))
    public double CalcularPerimetro()
    {
        return 2 * (Largo + Ancho);
    }
}

// Ejemplo de uso (Programa principal)
class Program
{
    static void Main(string[] args)
    {
        // Ejemplo con Círculo
        Circulo miCirculo = new Circulo(5.0);
        Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
        Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

        // Ejemplo con Rectángulo
        Rectangulo miRectangulo = new Rectangulo(4.0, 6.0);
        Console.WriteLine("Área del rectángulo: " + miRectangulo.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + miRectangulo.CalcularPerimetro());
    }
}