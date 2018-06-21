using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;

namespace Pilot.Helper
{
    public static class DocumentHelper
    {
        public static Stream GetReport(string name, string value)
        {
            string fileName = @"D:\Pilot\template.docx";
            string docText = null;
            byte[] byteArray = File.ReadAllBytes(fileName);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
                {
                    using (StreamReader reader = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = reader.ReadToEnd();
                    }

                    docText = docText.Replace("City", "Калуга");
                    docText = docText.Replace("Date", DateTime.Now.Date.ToString());
                    docText = docText.Replace("Com1", "ООО ТРЕШ");
                    docText = docText.Replace("Dir1", "Пупкин Пупок");
                    docText = docText.Replace("Citizen", "Иванов Иван Иванович");
                    docText = docText.Replace("INN", "11212121212");
                    docText = docText.Replace("KPP", "41234123455");

                    using (StreamWriter writer = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        writer.Write(docText);
                    }
                }
                return  new MemoryStream(stream.ToArray());
            }
        }
    }
}
