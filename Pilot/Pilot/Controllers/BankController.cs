using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Common.Model;
using Pilot.Repository.Implementations;
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
        private readonly BankRepository _bankRepository;

        public BankController(/*IEnterpriseRepository enterpriseRepository*/)
        {
            /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _bankRepository = new BankRepository(new DataCore.DataManager("Data Source=SQL6004.site4now.net;Initial Catalog=db_a3d8d7_pilottest_1;User Id=db_a3d8d7_pilottest_1_admin;Password=Rfrfirf70;"));
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
    }
}
