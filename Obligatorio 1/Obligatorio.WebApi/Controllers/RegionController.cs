using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Model.Models.In;
using Model.Models.Out;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.WebApi.AuxiliaryObjects;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/regions")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionLogic regionLogic;

        public RegionController(IRegionLogic regionLogic)
        {
            this.regionLogic = regionLogic;
        }

        //api/touristSpots
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.regionLogic.GetAll().Select(r => new RegionModelOut(r)));
        }

        // https://tools.ietf.org/html/rfc3986
        //api/touristSpots/default_name
        [HttpGet("{name}", Name = "GetRegion")]
        public IActionResult Get(string name)
        {
            if(name.Contains(" "))
            {
                return BadRequest("URIs should not contain blank spaces.");
            }
            string nameWithSpaces = name.Replace('_', ' ');
            try
            {
                var region = this.regionLogic.Get(nameWithSpaces);
                return Ok(new RegionModelOut(region));
            }
            catch (Exception ex)
            {
                return NotFound("There is no such region name.");
            }
        }


        //api/touristSpots/11
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Post([FromBody] RegionModelIn regionModel)
        {
            try
            {
                var region = regionModel.ToEntity();
                this.regionLogic.Add(region);
                return CreatedAtRoute(routeName: "GetRegion",
                                                    routeValues: new { name = regionModel.Name },
                                                        value: new RegionModelIn(region));
            }
            catch (Exception ex)
            {
                return BadRequest("A region with such name has been already registered.");
            }
        }

        //api/regions
        [HttpPut]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Put([FromBody] RegionAndTouristSpotIdentifier data)  
        {
            try
            {
                this.regionLogic.AddTouristSpotToRegion(data.RegionName, data.TouristSpotId);
                return Ok("Updated");
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                return NotFound("Either there is no such region in our database, or there is no such tourist spot id.");
            }
            catch (RepeatedObjectException)
            {
                return BadRequest("This tourist spot belongs to a different region."); //our tourist spots cannot move.
            }
            catch (InvalidCastException)
            {
                return BadRequest("The input format is not correct.");
            }
        }

        [HttpPut("modify")]
        //[Route("api/regions/modify")]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult TouristSpotRegionUpdate([FromBody] RegionAndTouristSpotIdentifier data)
        {
            try
            {
                this.regionLogic.ModifyTouristSpotRegion(data.RegionName, data.TouristSpotId);
                return Ok("Updated");
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                return NotFound("Either there is no such region in our database, or there is no such tourist spot id.");
            }
            catch (InvalidCastException)
            {
                return BadRequest("The input format is not correct.");
            }
        }
    }
}
