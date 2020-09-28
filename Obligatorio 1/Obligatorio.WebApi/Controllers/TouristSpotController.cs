using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(this.touristSpotLogic.GetAll().Select(ts => new TouristSpotModel(ts)));
            //return Ok(1);
        }

        //api/touristSpots/5
        [HttpGet("{id}", Name = "GetTouristSpot")]
        public IActionResult Get(int id)
        {
            if(id == -1) 
            {
                return Ok(this.touristSpotLogic.GetAll().Select(ts => new TouristSpotModel(ts)));
            }
            else
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
        }

        //api/touristSpots/11
        [HttpPost]
        public IActionResult Post([FromBody] TouristSpotModel touristSpotModel)
        {
            var anotherTSM = touristSpotModel;
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

        [HttpDelete]
        public IActionResult Delete([FromBody] TouristSpotModel touristSpotModel)
        {
            throw new NotImplementedException();
        }
    }
}
