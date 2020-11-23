using System;
using System.Collections.Generic;
using System.Web;
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
        /// <summary>
        /// Returns available accommodations in certain TouristSpot, given check in and out dates, and the number of guests.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /accommodationsaccommodations?touristSpotName=Playa de la balconada&checkInYear=2020&checkInMonth=11&checkInDay=22&checkOutYear=2020&checkOutMonth=11&checkOutDay=28&totalGuests=18&babies=7&kids=2&adults=2&retirees=7
        ///
        /// </remarks> 
        [HttpGet]
        public IActionResult Get()
        {
            var queryString = HttpUtility.ParseQueryString(this.HttpContext.Request.QueryString.Value);
            if (queryString.Count == 0)
            {
                List<AccommodationQueryOut> accommodations = this.accommodationLogic.GetAll();
                List<AccommodationModelOut> accommodationsToReturn = new List<AccommodationModelOut>();
                foreach (var item in accommodations)
                {
                    AccommodationModelOut a = new AccommodationModelOut(item);
                    accommodationsToReturn.Add(a);
                }
                return Ok(accommodationsToReturn);
            }
            else
            {
                try
                {
                    AccommodationModelIn accommodationModelIn = new AccommodationModelIn
                    {
                        TouristSpotName = queryString.Get("touristSpotName"),
                        CheckIn = new DateTime(
                             Int32.Parse(queryString.Get("checkInYear")),
                             Int32.Parse(queryString.Get("checkInMonth")),
                             Int32.Parse(queryString.Get("checkInDay"))
                            ),
                        CheckOut = new DateTime(
                             Int32.Parse(queryString.Get("checkOutYear")),
                             Int32.Parse(queryString.Get("checkOutMonth")),
                             Int32.Parse(queryString.Get("checkOutDay"))
                            ),
                        TotalGuests = Int32.Parse(queryString.Get("totalGuests")),
                        Babies = Int32.Parse(queryString.Get("babies")),
                        Kids = Int32.Parse(queryString.Get("kids")),
                        Adults = Int32.Parse(queryString.Get("adults")),
                        Retirees = Int32.Parse(queryString.Get("retirees"))
                    };
                    int tot = accommodationModelIn.Babies + accommodationModelIn.Kids 
                        + accommodationModelIn.Adults + accommodationModelIn.Retirees;
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
                catch (Exception e) 
                {
                    return BadRequest("Wrong input: incorrect query string");
                }
            }
            
        }
        /// <summary>
        /// Adds an Accommodation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /accommodations
        ///     {
        ///         "Name" : "Hotel del mar",
        ///         "Rating" : 5,
        ///         "Description" : "Rivera 379"
        ///         "PricePerNight" : 400,
        ///         FullCapacity : true,
        ///         "TouristSpotName" : "Playa de la balconada"
        ///     }
        ///
        /// </remarks>
        /// <param name="accommodationRegisterModel"></param>     

        //[ServiceFilter(typeof(AuthorizationAttributeFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] AccommodationRegisterModelIn accommodationRegisterModel)
        {
            try
            {
                var accommodation = accommodationRegisterModel.ToEntity();
                if (accommodation.Rating < 1 | accommodation.Rating > 5)
                {
                    throw new Exception();
                }
                this.accommodationLogic.Add(accommodation, accommodationRegisterModel.TouristSpotName);
                return Ok();
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
        /// <summary>
        /// Updates an accommodation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /accommodations/1
        ///     {
        ///         "WantToChangeCapacity" : true,
        ///         "FullCapacity" : false,
        ///         "Name" : "Hotel del mar"
        ///     }
        ///
        /// </remarks>
        /// <param name="accommodationPutModelIn"></param>
        [HttpPut]
        public IActionResult Put([FromBody] AccommodationPutModelIn accommodationPutModelIn)
        {
            try
            {
                AccommodationPutQueryIn accommodationPutQueryIn = new AccommodationPutQueryIn(accommodationPutModelIn);
                this.accommodationLogic.Update(accommodationPutQueryIn);
                return Ok(this.accommodationLogic.GetByName(accommodationPutQueryIn.Name));
            }
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return NotFound("There is no accommodation with such id.");
            }
            catch (NullReferenceException e) 
            {
                return NotFound("There is no accommodation with such id.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        /// Delete an Accommodation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /accommodations/Escollera
        ///
        /// </remarks>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            try
            {
                this.accommodationLogic.Delete(name);
                return Ok("Success");
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                return NotFound("There is no accommodation with such name.");
            }
        }

    }
}
