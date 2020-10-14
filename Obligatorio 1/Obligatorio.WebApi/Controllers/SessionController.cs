using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogic.Logics;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Models.In;
using Obligatorio.SessionInterface;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionLogic sessionLogic;

        public SessionController(ISessionLogic sessionLogic)
        {
            this.sessionLogic = sessionLogic;
        }

        // POST: api/sessions
        [HttpPost]
        public IActionResult Post([FromBody] SessionModelIn value)
        {
            string token = "";
            if (sessionLogic.IsValidAdmin(value.Email, value.Password)) 
            {
                token = sessionLogic.GetAdminToken();
            }
            return Ok(token);
        }
    }
}
