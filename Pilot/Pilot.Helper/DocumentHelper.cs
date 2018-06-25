using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using Pilot.Common.Model;

namespace Pilot.Helper
{
    public static class DocumentHelper
    {
        public static Stream GetReport(ReportResponse report)
        {
            //string fileName = @"h:\root\home\wd45dev-001\www\templats\template.docx";
            string fileName = @"D:\Pilot\ABON.docx";
            byte[] byteArray = File.ReadAllBytes(fileName);
            string docText = null;
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
                {
                    using (StreamReader reader = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        docText = reader.ReadToEnd();
                    }
                    Regex regexText = new Regex("TContractNumberT");
                    docText = regexText.Replace(docText, report.ContractNumber);

                    //docText = docText.Replace("TContractNumberT", report.ContractNumber);
                    docText = docText.Replace("TContractDateT", DateTime.Now.Date.ToString());
                    docText = docText.Replace("TEnterpriseT", report.Enterprise);
                    docText = docText.Replace("TEnterprisePersonT", report.EnterprisePerson);
                    docText = docText.Replace("TBaseT", report.Base);
                    docText = docText.Replace("TSectionAddressT", report.SectionAddress);
                    docText = docText.Replace("TSectionRoleT", report.SectionRole);
                    docText = docText.Replace("TSectionAreaT", report.SectionArea);
                    docText = docText.Replace("TContractPriceT", report.ContractPrice);

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
