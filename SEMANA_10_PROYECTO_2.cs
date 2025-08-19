using System;
using System.Collections.Generic;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Crear algunos conjuntos ficticios de ciudadanos
        HashSet<string> noVacunados = new HashSet<string> { "Ciudadano 1", "Ciudadano 2", "Ciudadano 3" };
        HashSet<string> ambasDosis = new HashSet<string> { "Ciudadano 4", "Ciudadano 5" };
        HashSet<string> soloPfizer = new HashSet<string> { "Ciudadano 6", "Ciudadano 7" };
        HashSet<string> soloAstraZeneca = new HashSet<string> { "Ciudadano 8", "Ciudadano 9" };

        // Crear el objeto PdfReport
        PdfReport report = new PdfReport();

        // Llamar al método para generar el reporte PDF
        report.CreatePdfReport(noVacunados, ambasDosis, soloPfizer, soloAstraZeneca);

        Console.WriteLine("Reporte generado exitosamente.");
    }
}

class PdfReport
{
    public void CreatePdfReport(HashSet<string> noVacunados, HashSet<string> ambasDosis, 
                                 HashSet<string> soloPfizer, HashSet<string> soloAstraZeneca)
    {
        // Crear el documento PDF
        PdfDocument doc = new PdfDocument();
        doc.Info.Title = "Reporte de Vacunación COVID-19";
        PdfPage page = doc.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 10);

        // Agregar contenido al PDF
        gfx.DrawString("Ciudadanos no vacunados:", font, XBrushes.Black, new XPoint(10, 20));
        int yPosition = 40;
        foreach (var ciudadano in noVacunados)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
        }

        gfx.DrawString("\nCiudadanos que han recibido ambas dosis:", font, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 20;
        foreach (var ciudadano in ambasDosis)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
        }

        gfx.DrawString("\nCiudadanos solo vacunados con Pfizer:", font, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 20;
        foreach (var ciudadano in soloPfizer)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
        }

        gfx.DrawString("\nCiudadanos solo vacunados con AstraZeneca:", font, XBrushes.Black, new XPoint(10, yPosition));
        yPosition += 20;
        foreach (var ciudadano in soloAstraZeneca)
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, new XPoint(10, yPosition));
            yPosition += 20;
        }

        // Guardar el archivo PDF
        string fileName = "Reporte_Vacunacion_COVID19.pdf";
        doc.Save(fileName);
    }
}
