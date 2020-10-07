using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Models.Out;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/accommodation")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationLogic accommodationLogic;

        public AccommodationController(IAccommodationLogic accommodationLogic) 
        { 
            this.accommodationLogic = accommodationLogic;
        }

        // GET: api/Accommodation
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.accommodationLogic.GetAll().Select(a => new AccommodationModelOut(a)));
        }

        // GET: api/Accommodation/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Accommodation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Accommodation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
