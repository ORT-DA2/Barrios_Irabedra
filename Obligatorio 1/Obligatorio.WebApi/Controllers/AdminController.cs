﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // POST: api/admins
        [HttpPost]
        public IActionResult Post([FromBody] AdminModelIn value)
        {
            try
            {
                Admin adminToRegister = value.ToEntity();
                this.adminLogic.Add(adminToRegister);
                return CreatedAtAction("AdminCreated", new AdminModelOut(adminToRegister));
                //return StatusCode(201, adminToRegister.ToString());
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

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdminModelIn value)
        {
            return Ok("");
        }
    }
}
