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
        /// <summary>
        /// Получить докумен
        /// </summary>
        [ProducesResponseType(typeof(ReportResponse), 200)]
        [HttpGet()]
        public IActionResult Get(ReportResponse report)
        {
            var date = DateTime.Now;
            var document = DocumentHelper.GetReport(report);
            return Report(document, $"ABON_{date}.docx");
        }
    }
}
