using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    class Fichier
    {
        public static void Lecturepdf(string nomf)
        {
            string chemin = @"C:/Users/badzo/Music/GESTION_BIBLIOTHEQUE - Copie (2) - Copie/GESTION_BIBLIOTHEQUE/Facture/";
            System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo(chemin + nomf);
            Process.Start(chemin + nomf);
        }

        //Suprimer fichier txt
        public static void Supf(string nomf)
        {
            string chemin = @"C:/Users/badzo/Music/GESTION_BIBLIOTHEQUE - Copie (2) - Copie/GESTION_BIBLIOTHEQUE/Facture/";
            System.IO.File.Delete(chemin + nomf + ".txt");
        }

        //Ecrire ligne sur un fichier txt
        public static void Ecrire_Fichiertxt(string nomFichier, string texte)
        {
            string chemin = (@"C:/Users/badzo/Pictures/WindowsFormsApp1/");
            StreamWriter fichierSortie = File.AppendText(chemin + nomFichier + ".txt");
            fichierSortie.WriteLine(texte);
            fichierSortie.Close();
        }

        //Creer fichier txt
        public static void Creer_Fichiertxt(string nomFichier)
        {
            string chemin = @"C:/Users/badzo/Music/GESTION_BIBLIOTHEQUE - Copie (2) - Copie/GESTION_BIBLIOTHEQUE/Facture/";
            StreamWriter fichierSortie = File.CreateText(chemin + nomFichier + ".txt");
            fichierSortie.Close();
        }

        //Convertir fichier txt en pdf
        public static void Convert(string nomf)
        {  // Creation dun objet de type document pdf
            string chemin = ("C:/Users/badzo/Music/GESTION_BIBLIOTHEQUE - Copie (2) - Copie/GESTION_BIBLIOTHEQUE/Facture/");
            string nomftxt = chemin + nomf + ".txt";
            PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
            //Creation page vide
            StreamReader readFile = File.OpenText(nomftxt);
            string line = null;
            int yPoint = 0;
            pdf.Info.Title = "TXT to PDF";
            PdfSharp.Pdf.PdfPage pdfPage = pdf.AddPage();
            //Creation XGraphis Object
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            //Creation du font avec XFont
            XFont font = new XFont("Arial", 13, XFontStyle.Bold);  //  new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            while (readFile.Peek() > 0)
            {
                line = readFile.ReadLine();
                graph.DrawString(line, font, XBrushes.Blue,
                      new XRect(20, yPoint, 150.0F, 150.0F), XStringFormats.TopLeft);
                yPoint += 7;

            }
            readFile.Close();
            readFile = null;
            //save fichier 
            System.IO.File.Delete(nomftxt);//supprimer ftx
            pdf.Save(chemin + nomf + ".pdf");
        }

        public static void Pdfi(string nomf, string line)
        {  // Creation dun objet de type document pdf
            string chemin = ("C:/Users/badzo/Documents/Visual Studio 2017/Projets/GESTION_FORAGE/GESTION_FORAGE/Factures/");
            PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
            PdfSharp.Pdf.PdfPage pdfPage = pdf.AddPage();
            int yPoint = 0;
            //Creation XGraphis Object
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            //Creation du font avec XFont
            XFont font = new XFont("Cambria", 13, XFontStyle.Regular);
            graph.DrawString(line, font, XBrushes.Blue,
                  new XRect(20, yPoint, 150.0F, 150.0F), XStringFormats.TopLeft);
            yPoint += 7;
            //save fichier 
            pdf.Save(chemin + nomf + ".pdf");
        }
    }
}
