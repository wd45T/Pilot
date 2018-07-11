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

        public async Task<Stream> GetReportXML(TypeDocData report)
        {
            string fileName = @"h:\root\home\wd45dev-001\www\templats\TypeDoc.docx";
            //string fileName = @"D:\Git\TypeDoc.docx";
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
                    docText = docText.Replace("TContractDateT", DateTime.Now.ToString("d"));

                    docText = docText.Replace("TEnterpriseT", report.Enterprise.FullName);
                    docText = docText.Replace("TEnterprisePersonT", report.Enterprise.ManagerName);
                    docText = docText.Replace("TBaseT", report.Enterprise.Base);

                    docText = docText.Replace("TPrepaidExpenseT", report.PrepaidExpense);
                    docText = docText.Replace("TPrepaidExpenseInWordsT", report.PrepaidExpenseInWords);
                    docText = docText.Replace("TBalancePriceT", report.BalancePrice);
                    docText = docText.Replace("TBalancePriceInWordsT", report.BalancePriceInWords);

                    docText = docText.Replace("TShortNameEnterpriseT", report.Enterprise.FullName);
                    docText = docText.Replace("TYAdressT", report.Enterprise.LegalAddress);
                    docText = docText.Replace("TPAdressT", report.Enterprise.MailingAddress);
                    docText = docText.Replace("TInnT", report.Enterprise.INN);
                    docText = docText.Replace("TKppT", report.Enterprise.KPP);
                    docText = docText.Replace("TOgrnT", report.Enterprise.OGRN);
                    docText = docText.Replace("TRcT", report.PaymentAccount.Account);
                    docText = docText.Replace("TBankNameT", report.Bank.FullNameBank);
                    docText = docText.Replace("TKcT", report.Bank.CorrespondingAccount);
                    docText = docText.Replace("TBikT", report.Bank.BIK);
                    docText = docText.Replace("TPositionPersonT", report.Enterprise.Position);
                    docText = docText.Replace("TShortNamePersonT", report.Enterprise.ManagerName);

                    using (StreamWriter writer = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                        await writer.WriteAsync(docText);


                    var mainPart = doc.MainDocumentPart;
                    var body = mainPart.Document.AppendChild(new Body());

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

                    _openXMLHelper.AddTable(mainPart, 1, tableDate);

                }
                return new MemoryStream(stream.ToArray());
            }
        }
    }
}
