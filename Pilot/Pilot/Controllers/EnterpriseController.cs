using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EnterpriseController : BaseController
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseController(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        /// <summary>
        /// Получить все предприятия
        /// </summary>
        //[ProducesResponseType(typeof(SomeResponse), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = (await _enterpriseRepository.GetDtoAll()).ToList();
            return Ok(resp);
        }
    }
}
