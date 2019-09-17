using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed;
using Xceed.Words.NET;

namespace lab_29_export_to_office
{
    class Program
    {
        static void Main(string[] args)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fileName = @"RabbitReport.docx";
            var desktopFileName = @"" + desktopPath + "//" + fileName;
            var doc = DocX.Create(desktopFileName);
            string timeTaken1 = "7.1234", timeTaken1000 = "8.234";
            Console.WriteLine(desktopFileName);

            
            doc.InsertParagraph("Rabbit Report");
            doc.InsertParagraph("Number of rabbits created = 1000");
            doc.InsertParagraph($"Time taken with 1 read = {timeTaken1} seconds");
            doc.InsertParagraph($"Time taken with 1000 reads = {timeTaken1000} seconds");
            doc.Save();

            Process.Start("WINWORD.EXE", desktopFileName);


        }
    }
}