using Microsoft.AspNetCore.Mvc;
using Pilot.API.Infrastructure;
using Pilot.Common.Model;
using Pilot.Common.Model.Common;
using Pilot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilot.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Получить все User
        /// </summary>
        [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<UserResponse>>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = (await _userRepository.GetDtoAll()).ToList();
            return Ok(resp);
        }
    }
}
