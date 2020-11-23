﻿using System;
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
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /regions
        ///
        /// </remarks>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.regionLogic.GetAll().Select(r => new RegionModelOut(r)));
        }

        /// <summary>
        /// Returns a region given a name.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /regions/"Region metropolitana"
        ///
        /// </remarks>
        /// <param name="name"></param>
        /// <returns></returns>
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
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /regions
        ///     {
        ///         "Name" : "Region metropolitana"
        ///     }
        ///
        /// </remarks>
        /// <param name="regionModel"></param>
        /// <returns></returns>
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
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return BadRequest("A region with such name has been already registered.");
            }
        }

        /// <summary>
        /// Adds a TouristSpot to an existing Region.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /regions
        ///     {
        ///         "RegionName" : "Region metropolitana",
        ///         "TouristSpotName" : "Playa de la balconada"
        ///     }
        ///
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Put([FromBody] RegionAndTouristSpotIdentifier data)  
        {
            try
            {
                this.regionLogic.AddTouristSpotToRegion(data.RegionName, data.TouristSpotName);
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
    }
}
