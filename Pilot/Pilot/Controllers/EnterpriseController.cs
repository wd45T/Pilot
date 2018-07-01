﻿using Microsoft.AspNetCore.Mvc;
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

        public EnterpriseController(/*IEnterpriseRepository enterpriseRepository*/)
        {
            /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _enterpriseRepository = new EnterpriseRepository(new DataCore.DataManager("Data Source=SQL6004.site4now.net;Initial Catalog=db_a3d8d7_pilottest_1;User Id=db_a3d8d7_pilottest_1_admin;Password=Rfrfirf70;"));
        }

        /// <summary>
        /// Получить все предприятия
        /// </summary>
        [ProducesResponseType(typeof(EnterpriseResponse), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = (await _enterpriseRepository.GetDtoAll()).ToList();
            return Ok(resp);
        }

    }
}
