using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Model.Models.In;
using Model.Models.Out;
using Obligatorio.BusinessLogic.CustomExceptions;
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
        /// <summary>
        /// Returns all regions.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.regionLogic.GetAll().Select(r => new RegionModelOut(r)));
        }
        /// <summary>
        /// Returns a region given a name.
        /// </summary>
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
        /// <summary>
        /// Adds a region.
        /// </summary>
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
        /// <summary>
        /// Adds a TouristSpot to an existing Region.
        /// </summary>
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
        /// <summary>
        /// Updates a TouristSpot moving it to a different Region.
        /// </summary>
        [HttpPut("modify")]
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
