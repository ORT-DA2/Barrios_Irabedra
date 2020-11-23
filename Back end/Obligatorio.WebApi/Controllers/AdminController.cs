using System;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/admins")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationAttributeFilter))]
    public class AdminController : ControllerBase
    {

        private readonly IAdminLogic adminLogic;

        public AdminController(IAdminLogic adminLogic)
        {
            this.adminLogic = adminLogic;
        }

        /// <summary>
        /// Adds an Admin.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /admin
        ///     {
        ///        "Name" : "Juan",
        ///        "Email" : "admin1@gmail.com",
        ///        "Password" : "SafEPassW0rd"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AdminModelIn value)
        {
            try
            {
                Admin adminToRegister = value.ToEntity();
                this.adminLogic.Add(adminToRegister);
                return Ok("AdminCreated");
            }
            catch (RepeatedObjectException e)
            {
                return BadRequest("An admin with such name has been already registered.");
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Delete an Admin.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /admin/admin1@gmail.com
        ///     
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            try
            {
                this.adminLogic.Delete(email);
                return Ok();
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                return BadRequest("Theres no admin with such email.");
            }
        }
        /// <summary>
        /// Updates a Admin.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /admin/admin1@gmail.com
        ///     {
        ///        "Name" : "Juan",
        ///        "Email" : "admin1@gmail.com",
        ///        "Password" : "SafEPassW0rd"
        ///     }
        ///     
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{email}")]
        public IActionResult Put(string email, [FromBody] AdminModelIn value)
        {
            try
            {
                Admin adminToUpdate = value.ToEntity();
                this.adminLogic.Update(email, adminToUpdate);
                return Ok();
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                return BadRequest("Theres no admin with such email.");
            }
        }
    }
}
