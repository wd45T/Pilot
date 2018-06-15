using Microsoft.AspNetCore.Mvc;
using Pilot.Common.Model.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Pilot.API.Infrastructure
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Пустой OK ответ
        /// </summary>
        /// <returns></returns>
        protected OkObjectResult OkEmpty()
        {
            return Ok(null);
        }

        /// <summary>
        /// OK с data
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override OkObjectResult Ok(object value)
        {
            return base.Ok(new ResponseWrapper<object>
            {
                Data = value,
                Error = null,
                Meta = null,
                Status = (int)HttpStatusCode.OK
            });
        }

        protected FileStreamResult Report(Stream report, string reportName)
        {
            return File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", reportName);
        }
    }
}
