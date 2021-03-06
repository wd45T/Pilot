﻿using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using Pilot.Common.Model;
using PIK.BOP.IDP.Site.Helpers;
using System.Net;
using Pilot.Common.Model.TableOpenXML;
using System.Threading.Tasks;

namespace Pilot.Helper
{
    public class DocumentHelper
    {
        private readonly OpenXMLHelper _openXMLHelper;

        public DocumentHelper()
        {
            _openXMLHelper = new OpenXMLHelper();
        }

        public static Stream GetReport(ReportResponse report)
        {
            string fileName = @"h:\root\home\wd45dev-001\www\templats\ABON.docx";
            //string fileName = @"D:\Pilot\template.docx";
            //string fileName = @"D:\Pilot\ABON.docx";
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

                    //docText = docText.Replace("City", report.City);
                    //docText = docText.Replace("Date", DateTime.Now.Date.ToString());
                    //docText = docText.Replace("Com1", report.Com1);
                    //docText = docText.Replace("Dir1", report.Dir1);
                    //docText = docText.Replace("Citizen", report.Citizen);
                    //docText = docText.Replace("INN", report.INN);
                    //docText = docText.Replace("KPP", report.KPP);
                    //docText = docText.Replace("Bank", report.Bank);
                    //docText = docText.Replace("RA", report.RA);
                    //docText = docText.Replace("KA", report.KA);
                    //docText = docText.Replace("BIK", report.BIK);
                    //docText = docText.Replace("YAdres", report.YAdres);
                    //docText = docText.Replace("PAdres", report.PAdres);
                    //docText = docText.Replace("CirtizenReg", report.CirtizenReg);
                    //docText = docText.Replace("CitipzenP", report.CitipzenP);
                    //docText = docText.Replace("CiptizePasport", report.CiptizePasport);
                    //docText = docText.Replace("CiwtizePaspwortNuwmber", report.CiwtizePaspwortNuwmber);
                    //docText = docText.Replace("CitaizePaspsorDadte", report.CitaizePaspsorDadte);
                    //docText = docText.Replace("CitsizePassportIsssued", report.CitsizePassportIsssued);
                    //docText = docText.Replace("CitizeTel", report.CitizeTel);

                    //Regex regexText = new Regex("TContractNumberT");
                    //docText = regexText.Replace(docText, report.ContractNumber);

                    docText = docText.Replace("TContractNumberT", report.ContractNumber);
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

        public async Task<Stream> GetReportXML(ReportResponse report)
        {
            string fileName = @"h:\root\home\wd45dev-001\www\templats\ABON.docx";
            //string fileName = @"D:\Git\ABON.docx";
            byte[] byteArray = File.ReadAllBytes(fileName);
            string docText = null;
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
                {
                    using (StreamReader reader = new StreamReader(doc.MainDocumentPart.GetStream()))
                        docText = await reader.ReadToEndAsync();


                    docText = docText.Replace("TContractNumberT", report.ContractNumber);
                    docText = docText.Replace("TContractDateT", DateTime.Now.Date.ToString());
                    docText = docText.Replace("TEnterpriseT", report.Enterprise);
                    docText = docText.Replace("TEnterprisePersonT", report.EnterprisePerson);
                    docText = docText.Replace("TBaseT", report.Base);
                    docText = docText.Replace("TSectionAddressT", report.SectionAddress);
                    docText = docText.Replace("TSectionRoleT", report.SectionRole);
                    docText = docText.Replace("TSectionAreaT", report.SectionArea);
                    docText = docText.Replace("TContractPriceT", report.ContractPrice);

                    using (StreamWriter writer = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                        await writer.WriteAsync(docText);


                    var mainPart = doc.MainDocumentPart;
                    //mainPart.Document = new Document();
                    var body = mainPart.Document.AppendChild(new Body());

                    body.Append(_openXMLHelper.GenerateParagraph(null, new ParagraphProperties { SectionProperties = _openXMLHelper.GenerateSectionPageBreak() }));

                    #region AddImage
                    ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(report.URLImage ?? "https://i.ytimg.com/vi/6aKxU_sQGiw/maxresdefault.jpg");
                    req.UseDefaultCredentials = true;
                    req.PreAuthenticate = true;
                    req.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                    var str = resp.GetResponseStream();
                    imagePart.FeedData(str);

                    //var img = Image.FromStream(str);

                    //var iWidth = img.Width * 500;
                    //var iHeight = img.Height * 500;

                    _openXMLHelper.AddImageToBody(doc, mainPart.GetIdOfPart(imagePart), 5311500, 4339000);

                    #endregion AddImage


                    //body.Append(_openXMLHelper.GenerateParagraph(null, new ParagraphProperties { SectionProperties = _openXMLHelper.GenerateSectionPageBreak() }));
                    body.Append(_openXMLHelper.GenerateParagraph(""));

                    var tableDate = new TableData
                    {
                        HeaderTable = new List<string>
                            {
                                "Вид работ",
                                "Вид пользования",
                                "Расположение",
                                "Площадь",
                                "Сроки выполнения работ",
                                "Стоимость услуг"
                            },
                        Rows = new List<List<string>>
                            {
                                new List<string>
                                {
                                    "Разработка проектов освоение лесов",
                                    "Сельское хозяйство",
                                    "Белорецкое лесничество, Журавлинское участковое лесничество, квартал №189 ...",
                                    "9,7 га",
                                    "2 месяца",
                                    "10 000,00 рублей",
                                },
                                new List<string>
                                {
                                    "Внесение изменений в проект освоение лесов",
                                    "Строительство линейного объекта",
                                    "Дюртилинское лестничесвто, Дютиринское участковое лестничество, Калтасинское сельское лесничество ...",
                                    "45,6 га",
                                    "3 месяца",
                                    "20 000,00 рублей",
                                },
                            }
                    };

                    tableDate.Rows.AddRange(report.Rows);

                    body.Append(_openXMLHelper.CreateTable(tableDate));
                }
                return new MemoryStream(stream.ToArray());
            }
        }
    }
}
