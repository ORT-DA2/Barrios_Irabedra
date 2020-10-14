using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Models.In;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IAdminLogic adminLogic;

        public SessionController(IAdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }

        // POST: api/sessions
        [HttpPost]
        public IActionResult Post([FromBody] SessionModelIn value)
        {

            return Ok("");
        }
    }
}
