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
            string fileName = @"D:\Pilot\doc.docx";
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fileName, true))
            {

                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Regex regexText = new Regex("doc");
                docText = regexText.Replace(docText, "alalalaallaaaa");
                //regexText = new Regex("name");
                //docText = regexText.Replace(docText, name);
                //regexText = new Regex("value");
                //docText = regexText.Replace(docText, value);

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream()))
                {
                    sw.Write(docText);
                }

                return new MemoryStream();
            }

        }

        private static byte[] CreatePackageAsBytes(WordprocessingDocument p)
        {
            using (var mstm = new MemoryStream())
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(mstm, WordprocessingDocumentType.Document))
                {
                
                }
                mstm.Flush();
                mstm.Close();
                return mstm.ToArray();
            }
        }
    }
}
