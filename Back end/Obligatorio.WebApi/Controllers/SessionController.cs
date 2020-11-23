using Microsoft.AspNetCore.Mvc;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using Obligatorio.SessionInterface;
using Obligatorio.WebApi.AuxiliaryObjects;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Add a new admin.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] SessionModelIn value)
        {
            try
            {
                Admin admin = value.ToEntity();
                this.sessionLogic.Add(admin);
                return Ok();
            }
            catch (Exception)
            {
               return BadRequest("Somewthing went wrong!");
            }
        }

        /// <summary>
        /// Creates a new Session.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /sessions
        ///     {
        ///         "Email" : "admin1@gmail.com",
        ///         "Password" : "SafEPassW0rd"
        ///     }
        ///
        /// </remarks>
        [HttpGet]
        public IActionResult Get()
        {
            var headerValues = this.HttpContext.Request.Headers;
            var email = headerValues["email"];
            var password = headerValues["password"];
            if (sessionLogic.IsValidAdmin(email, password)) 
            {
                string token = sessionLogic.GetAdminToken();
                return Ok(new ResponseMessage { Message = token });
            }
            return BadRequest("Wrong Email or Password");
        }
    }
}
