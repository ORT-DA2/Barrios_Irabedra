using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models.In;
using Model.Models.Out;
using Newtonsoft.Json;
using Obligatorio.BusinessLogicInterface.Interfaces;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/touristSpots")]
    [ApiController]
    public class TouristSpotController : ControllerBase
    {
        private readonly ITouristSpotLogic touristSpotLogic;

        public TouristSpotController(ITouristSpotLogic touristSpotLogic)
        {
            this.touristSpotLogic = touristSpotLogic;
        }

        //api/touristSpots
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.touristSpotLogic.GetAll().Select(ts => new TouristSpotModelOut(ts)));
        }

        //api/touristSpots/5
        [HttpGet("{id}", Name = "GetTouristSpot")]
        public IActionResult Get(int id)
        {
            try
            {
                var touristSpot = this.touristSpotLogic.Get(id);
                return Ok(new TouristSpotModelOut(touristSpot));
            }
            catch (Exception ex)
            {
                return NotFound("There is no such tourist spot id.");
            }
        }

        //api/touristSpots/11
        [HttpPost]
        public IActionResult Post([FromBody] TouristSpotModelIn touristSpotModel)
        {
            try
            {
                var touristSpot = touristSpotModel.ToEntity();
                this.touristSpotLogic.Add(touristSpot);
                return CreatedAtRoute(routeName: "GetTouristSpot",
                                                    routeValues: new { id = touristSpotModel.Id },
                                                        value: new TouristSpotModelIn(touristSpot));
            }
            catch (Exception ex)
            {
                return BadRequest("A tourist spot with such name has been already registered.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.touristSpotLogic.Delete(id);
                return Ok("Success.");
            }
            catch (Exception ex)
            {
                return NotFound("There is no tourist spot with such id.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TouristSpotModelIn dataToUpdate)
        {
            try
            {
                var touristSpot = dataToUpdate.ToEntity();
                this.touristSpotLogic.Update(id, touristSpot);
                var touristSpotToReturn = this.touristSpotLogic.Get(id);
                return Ok(new TouristSpotModelOut(touristSpotToReturn));
            }
            catch (Exception ex)
            {
                return NotFound("There is no tourist spot with such id.");
            }
        }
    }


}
