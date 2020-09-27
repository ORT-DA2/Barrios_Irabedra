using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Out;
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
            return Ok(this.touristSpotLogic.GetAll().Select(ts => new TouristSpotModel(ts)));
        }

        //api/touristSpots/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var touristSpot = this.touristSpotLogic.Get(id);
                return Ok(new TouristSpotModel(touristSpot));
            }
            catch (Exception ex)
            {
                return NotFound("There is no such tourist spot id.");
            }
        }

        //api/touristSpots/11
        [HttpPost]
        public IActionResult Post([FromBody] TouristSpotModel touristSpotModel)
        {
            try
            {
                var touristSpot = touristSpotModel.ToEntity();
                this.touristSpotLogic.Add(touristSpot);
                return CreatedAtRoute(routeName: "GetTouristSpot",
                                                    routeValues: new { id = touristSpotModel.Id },
                                                        value: new TouristSpotModel(touristSpot));
            }
            catch (Exception ex)
            {
                return BadRequest("A tourist spot with such id has been already registered.");
            }
        }
    }
}
