using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Post([FromBody] SessionModelIn value)
        {
            string token = "";
            if (sessionLogic.IsValidAdmin(value.Email, value.Password)) 
            {
                token = sessionLogic.GetAdminToken();
                return Ok(token);
            }
            return BadRequest("Wrong Email or Password");
        }
    }
}
