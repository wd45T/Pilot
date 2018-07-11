using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Common.Model;
using Pilot.Helper;
using Pilot.Repository.Implementations;
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
        [ProducesResponseType(typeof(EnterpriseResponse), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = await _enterpriseRepository.GetDtoAll();
            return Ok(resp);
        }

        /// <summary>
        /// Получить все предприятия
        /// </summary>
        [ProducesResponseType(typeof(EnterpriseResponse), 200)]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var resp = await _enterpriseRepository.GetDtoById(id);
            return Ok(resp);
        }

    }
}
