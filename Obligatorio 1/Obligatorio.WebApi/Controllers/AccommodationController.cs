﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using Obligatorio.Model.Models.In;
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
        public IActionResult Get([FromBody] AccommodationModelIn accommodationModelIn)
        {
            int tot = accommodationModelIn.Babies + accommodationModelIn.Kids + accommodationModelIn.Adults;
            if (accommodationModelIn.CantTotalHuespedes != tot) 
            {
                return BadRequest("Wrong input: the number of hosts is incorrect.");
            }
            AccommodationQueryIn accommodationQueryIn = new AccommodationQueryIn(accommodationModelIn);
            List<AccommodationQueryOut> accommodations = this.accommodationLogic.GetByTouristSpot(accommodationQueryIn);
            List<AccommodationModelOut> accommodationsToReturn = new List<AccommodationModelOut>();
            foreach (var item in accommodations)
            {
                AccommodationModelOut a = new AccommodationModelOut(item);
                accommodationsToReturn.Add(a);
            }
            return Ok(accommodationsToReturn);
        }


        // GET: api/Accommodation/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Accommodation
        [HttpPost]
        public void Post([FromBody] AccommodationRegisterModelIn value)
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
