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
            string fileName = @"h:\root\home\wd45dev-001\www\templats\template.docx";
            byte[] byteArray = File.ReadAllBytes(fileName);
            string docText = null;
            //byte[] byteArray = Properties.Resources.template;
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
                    docText = docText.Replace("Bank", "ПАО Сбербанк");
                    docText = docText.Replace("RA", "12354354186453496456746846");
                    docText = docText.Replace("KA", "216545648764864645454564");
                    docText = docText.Replace("BIK", "14555448787");
                    docText = docText.Replace("YAdres", "Москва");
                    docText = docText.Replace("PAdres", "Питер");
                    docText = docText.Replace("CirtizenReg", "Калуга ул Кирова");
                    docText = docText.Replace("CitipzenP", "Москва ул Кирова");
                    docText = docText.Replace("CiptizePasport", "14578");
                    docText = docText.Replace("CiwtizePaspwortNuwmber", "1457");
                    docText = docText.Replace("CitaizePaspsorDadte", "10 октября 1958");
                    docText = docText.Replace("CitsizePassportIsssued", "УФМС Росии по Кал уобласти блабла");
                    docText = docText.Replace("CitizeTel", "35-96-89");

                    using (StreamWriter writer = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        writer.Write(docText);
                    }
                }
                return new MemoryStream(stream.ToArray());
            }
        }
    }
}
