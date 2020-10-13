﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models.In;
using Model.Models.Out;
using Newtonsoft.Json;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.WebApi.Filters;

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
            if (Request.QueryString.Value is null)
            {
                return Ok(this.touristSpotLogic.GetAll().Select(ts => new TouristSpotModelOut(ts)));
            }
            else
            {
                List<TouristSpotModelOut> touristSpots = new List<TouristSpotModelOut>();
                string arguments = Request.QueryString.Value.Split('?')[1];  //categoryName=%22Nautico%22&categoryName=%22Malls%22
                List<string> criteria = arguments.Split('&').ToList<String>(); //categoryName=%22Nautico%22
                string sortingRegion = "";
                bool queryStringHasCategory = false;
                foreach (var param in criteria)
                {
                    string regionName = param.Split('=')[0];
                    if (regionName != "regionName")
                    {
                        string value = param.Split('=')[1].Replace("%22", "");
                        value = value.Replace("%20", " ");
                        touristSpots.AddRange(
                            touristSpotLogic.FindByCategory(value).Select(ts => new TouristSpotModelOut(ts)));
                        queryStringHasCategory = true;
                    }
                    else
                    {
                        if (sortingRegion != "")
                        {
                            return BadRequest("Remember to select only one region.");
                        }
                        sortingRegion = param.Split('=')[1].Replace("%22", "");
                        sortingRegion = sortingRegion.Replace("%20", " ");
                    }
                }
                List<TouristSpotModelOut> touristSpotsWithNoDuplicates = new List<TouristSpotModelOut>();
                foreach (var ts in touristSpots)
                {
                    if (!touristSpotsWithNoDuplicates.Contains(ts))
                    {
                        touristSpotsWithNoDuplicates.Add(ts);
                    }
                }
                sortingRegion = sortingRegion.Trim();
                if (sortingRegion is null || sortingRegion == "")
                {
                    return BadRequest("You need to specify the region.");
                }
                List<TouristSpotModelOut> touristSpotbyRegion = new List<TouristSpotModelOut>();
                touristSpotbyRegion.AddRange(
                            touristSpotLogic.FindByRegion(sortingRegion).Select(ts => new TouristSpotModelOut(ts)));
                List<TouristSpotModelOut> touristSpotsReturn = new List<TouristSpotModelOut>();
                foreach (var item in touristSpotbyRegion)
                {
                    if (touristSpotsWithNoDuplicates.Contains(item))
                    {
                        touristSpotsReturn.Add(item);
                    }
                }
                if (queryStringHasCategory)
                {
                    return Ok(touristSpotsReturn);
                }
                else 
                {
                    return Ok(touristSpotbyRegion);
                }

            }
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
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
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
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
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
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
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
