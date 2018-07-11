using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Common.Model;
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
    public class BankController : BaseController
    {
        private readonly IBankRepository _bankRepository;

        public BankController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        /// <summary>
        /// Получить все банки
        /// </summary>
        [ProducesResponseType(typeof(BankResponse), 200)]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var resp = await _bankRepository.GetDtoAll();
            return Ok(resp);
        }

        /// <summary>
        /// Получить банк по БИК
        /// </summary>
        [ProducesResponseType(typeof(BankResponse), 200)]
        [HttpGet("GetByBIK")]
        public async Task<IActionResult> GetBankByBIK(string bik)
        {
            var resp = await _bankRepository.GetBankByBIK(bik);
            return Ok(resp);
        }

        /// <summary>
        /// Получить банк по ID
        /// </summary>
        [ProducesResponseType(typeof(BankResponse), 200)]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetBankById(Guid id)
        {
            var resp = await _bankRepository.GetDtoById(id);
            return Ok(resp);
        }
    }
}

