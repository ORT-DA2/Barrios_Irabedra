using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/accommodations")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationLogic accommodationLogic;

        public AccommodationController(IAccommodationLogic accommodationLogic)
        {
            this.accommodationLogic = accommodationLogic;
        }

        [HttpGet]
        public IActionResult Get([FromBody] AccommodationModelIn accommodationModelIn)
        {
            int tot = accommodationModelIn.Babies + accommodationModelIn.Kids + accommodationModelIn.Adults;
            if (accommodationModelIn.TotalGuests != tot)
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

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Post([FromBody] AccommodationRegisterModelIn accommodationRegisterModel)
        {
            try
            {
                var accommodation = accommodationRegisterModel.ToEntity();
                if (accommodation.Rating < 1 | accommodation.Rating > 5)
                {
                    throw new Exception();
                }
                this.accommodationLogic.Add(accommodation, accommodationRegisterModel.TouristSpotId);
                return CreatedAtRoute(routeName: "GetAccommodation",
                                                    routeValues: new { name = accommodationRegisterModel.Name },
                                                        value: new AccommodationRegisterModelIn(accommodation));
            }
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return BadRequest("There is no such tourist spot id.");
            }
            catch (RepeatedObjectException e)
            {
                return BadRequest("An accommodation with such name has been already registered.");
            }
            catch (Exception exc) 
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccommodationPutModelIn accommodationPutModelIn)
        {
            try
            {
                AccommodationPutQueryIn accommodationPutQueryIn = new AccommodationPutQueryIn(accommodationPutModelIn,id);
                this.accommodationLogic.Update(accommodationPutQueryIn);
                return Ok(this.accommodationLogic.GetById(accommodationPutQueryIn.AccommodationId));
            }
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return NotFound("There is no accommodation with such id.");
            }
            catch (Exception e) 
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
