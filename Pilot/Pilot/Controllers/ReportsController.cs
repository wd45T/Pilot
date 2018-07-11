using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Common.Model;
using Pilot.Helper;
using Pilot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReportsController : BaseController
    {
        private readonly DocumentHelper _documentHelper;
        private readonly IBankRepository _bankRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IPaymentAccountRepository _paymentAccountRepository;

        public ReportsController(
            IBankRepository bankRepository,
            IEnterpriseRepository enterpriseRepository,
            IPaymentAccountRepository paymentAccountRepository
            )
        {
            _bankRepository = bankRepository;
            _enterpriseRepository = enterpriseRepository;
            _paymentAccountRepository = paymentAccountRepository;
            _documentHelper = new DocumentHelper();
        }

        /// <summary>
        /// Получить докумен
        /// </summary>
        //[ProducesResponseType(typeof(), 200)]
        [HttpPost()]
        public async Task<IActionResult> GetReport([FromBody] TypeDocRequest report)
        {
            var reportData = new TypeDocData
            {
                ContractNumber = report.ContractNumber,
                BalancePrice = report.BalancePrice,
                BalancePriceInWords = report.BalancePriceInWords,
                PrepaidExpense = report.PrepaidExpense,
                PrepaidExpenseInWords = report.PrepaidExpenseInWords,

                Enterprise = await _enterpriseRepository.GetDtoById(report.EnterpriseId),
                Bank = await _bankRepository.GetDtoById(report.BankId),
                PaymentAccount = await _paymentAccountRepository.GetDtoById(report.PaymentAccountId),

                Rows = report.Rows
            };
            var date = DateTime.Now;
            var document = await _documentHelper.GetReportXML(reportData);
            return Report(document, $"TypeDoc_{date}.docx");
        }
    }
}
