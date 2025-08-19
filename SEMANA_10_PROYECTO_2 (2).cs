using System;
using System.Collections.Generic;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Crear un conjunto ficticio de 500 ciudadanos
        HashSet<string> todosLosCiudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todosLosCiudadanos.Add($"Ciudadano {i}");
        }

        // Crear un conjunto ficticio de 75 ciudadanos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        Random rand = new Random();
        while (vacunadosPfizer.Count < 75)
        {
            vacunadosPfizer.Add($"Ciudadano {rand.Next(1, 501)}");
        }

        // Crear un conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca
        HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
        while (vacunadosAstraZeneca.Count < 75)
        {
            vacunadosAstraZeneca.Add($"Ciudadano {rand.Next(1, 501)}");
        }

        // Aplicar operaciones de teoría de conjuntos

        // Ciudadanos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(todosLosCiudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos que han recibido ambas dosis
        HashSet<string> ambasDosis = new HashSet<string>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstraZeneca);

        // Ciudadanos solo vacunados con Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos solo vacunados con AstraZeneca
        HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        // Generar un reporte en PDF con los resultados
        PdfReport report = new PdfReport();
        report.CreatePdfReport(todosLosCiudadanos, noVacunados, ambasDosis, soloPfizer, soloAstraZeneca);

        Console.WriteLine("Reporte generado exitosamente.");
    }
}

class PdfReport
{
    public void CreatePdfReport(HashSet<string> todosLosCiudadanos, HashSet<string> noVacunados, 
                                 HashSet<string> ambasDosis, HashSet<string> soloPfizer, HashSet<string> soloAstraZeneca)
    {
        PdfDocument doc = new PdfDocument();
        doc.Info.Title = "Reporte de Vacunación COVID-19";
        PdfPage page = doc.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 10);
        XFont sectionFont = new XFont("Verdana", 14, XFontStyle.Bold);

        // Establecer la posición inicial
        int yPosition = 20;

        // Agregar el título al PDF
        gfx.DrawString("Reporte de Vacunación COVID-19", sectionFont, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 30;

        // Agregar todos los ciudadanos
        gfx.DrawString("1. Todos los Ciudadanos:", sectionFont, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 25;
        foreach (var ciudadano in todosLosCiudadanos)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
            if (yPosition > 750) // Si se llena la página, añadir nueva
            {
                page = doc.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPosition = 20;
            }
        }

        // Espacio entre secciones
        yPosition += 10;

        // Agregar "Ciudadanos no vacunados"
        gfx.DrawString("2. Ciudadanos no vacunados:", sectionFont, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 25;
        foreach (var ciudadano in noVacunados)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
            if (yPosition > 750) // Si se llena la página, añadir nueva
            {
                page = doc.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPosition = 20;
            }
        }

        // Espacio entre secciones
        yPosition += 10;

        // Agregar "Ciudadanos que han recibido ambas dosis"
        gfx.DrawString("3. Ciudadanos que han recibido ambas dosis:", sectionFont, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 25;
        foreach (var ciudadano in ambasDosis)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
            if (yPosition > 750) // Si se llena la página, añadir nueva
            {
                page = doc.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPosition = 20;
            }
        }

        // Espacio entre secciones
        yPosition += 10;

        // Agregar "Ciudadanos solo vacunados con Pfizer"
        gfx.DrawString("4. Ciudadanos solo vacunados con Pfizer:", sectionFont, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 25;
        foreach (var ciudadano in soloPfizer)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
            if (yPosition > 750) // Si se llena la página, añadir nueva
            {
                page = doc.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPosition = 20;
            }
        }

        // Espacio entre secciones
        yPosition += 10;

        // Agregar "Ciudadanos solo vacunados con AstraZeneca"
        gfx.DrawString("5. Ciudadanos solo vacunados con AstraZeneca:", sectionFont, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 25;
        foreach (var ciudadano in soloAstraZeneca)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
            if (yPosition > 750) // Si se llena la página, añadir nueva
            {
                page = doc.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPosition = 20;
            }
        }

        // Guardar el archivo PDF
        string fileName = "Reporte_Vacunacion_COVID19.pdf";
        doc.Save(fileName);
    }
}
