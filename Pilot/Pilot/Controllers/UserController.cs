using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Common.Model;
using Pilot.Common.Model.Common;
using Pilot.Helper;
using Pilot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.API.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        //private readonly IUserRepository _userRepository;

        //public UserController(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        ///// <summary>
        ///// Получить все User
        ///// </summary>
        ////[ProducesResponseType(typeof(SomeResponse), 200)]
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var resp = (await _userRepository.GetDtoAll()).ToList();
        //    return Ok(resp);
        //}

        /// <summary>
        /// Получить документ @"templates\template.docx"
        /// </summary>
        //[ProducesResponseType(typeof(SomeResponse), 200)]
        [HttpGet("{name}&{value}")]
        public IActionResult Get(string name, string value)
        {
            var date = DateTime.Now;
            var document = DocumentHelper.GetReport(name, value);
            return Report(document, $"договор_{date}.docx");
        }
    }
}
