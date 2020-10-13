using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Models.In;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/admins")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationAttributeFilter))]
    public class AdminController : ControllerBase
    {

        private readonly IAdminLogic adminLogic;

        // POST: api/Admin
        [HttpPost]
        public IActionResult Post([FromBody] AdminModelIn value)
        {
            return Ok("");
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdminModelIn value)
        {
            return Ok("");
        }
    }
}
