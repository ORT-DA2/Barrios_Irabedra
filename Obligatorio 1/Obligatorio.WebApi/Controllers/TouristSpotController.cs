using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(this.touristSpotLogic.GetAll());
        }

        //api/touristSpots?id=5
        [HttpGet("{id}")]
        public IActionResult Get(int id) //id con minuscula pero no sabemos si es el mismo que el de la clase TouristSpot.Id
        {
            throw new NotImplementedException();
        }


    }
}
