using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Common.Model;
using Pilot.Helper;
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
        public ReportsController()
        {
            _documentHelper = new DocumentHelper();
        }

        /// <summary>
        /// Получить докумен
        /// </summary>
        //[ProducesResponseType(typeof(), 200)]
        [HttpPost()]
        public IActionResult GetReport([FromBody]ReportResponse report)
        {
            var date = DateTime.Now;
            var document = _documentHelper.GetReportXML();
            return Report(document, $"ABON_{date}.docx");
        }
    }
}
