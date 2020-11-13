using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.Models.In;
using Model.Models.Out;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [EnableCors("AllowAngularFrontEndClientApp")]
    //[System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/touristSpots")]
    [ApiController]
    public class TouristSpotController : ControllerBase
    {
        private readonly ITouristSpotLogic touristSpotLogic;

        public TouristSpotController(ITouristSpotLogic touristSpotLogic)
        {
            this.touristSpotLogic = touristSpotLogic;
        }



        /// <summary>
        /// Return all TouristSpots given a Region and a list of Categories.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /touristSpots/?regionName="Region metropolitana"&categoryName="Nautical"
        ///     {
        ///     }
        ///
        /// </remarks>
        [HttpGet]
        public IActionResult Get(string category = "all", string region = null)
        {
            List<TouristSpotModelOut> ret = new List<TouristSpotModelOut>();
            if (category == "all")
            {
                if(region is null)
                {
                    ret = GetAll();
                    return Ok(ret);
                }
                else
                {
                    return Ok(this.touristSpotLogic.FindByRegion(region).Select(ts => new TouristSpotModelOut(ts)));
                }
            }
            else
            {
                List<TouristSpotModelOut> touristSpotsWithinRegion = GetByRegion(this.Request.QueryString.Value);
                List<TouristSpotModelOut> touristSpotsWithinCategories = GetByAllCategories(this.Request.QueryString.Value);
                ret = Intersect(touristSpotsWithinCategories, touristSpotsWithinRegion);
                return Ok(ret);
            }
        }

        private List<TouristSpotModelOut> GetByAllCategories(string queryString)
        {
            List<TouristSpotModelOut> ret = new List<TouristSpotModelOut>();
            var individualCategories = Parse("category", queryString);
            foreach (var item in individualCategories)
            {
                var touristSpotsFoundByCategory = this.touristSpotLogic.FindByCategory(item).ToList<TouristSpot>();
                if (ret.Count == 0)
                {
                    ret.AddRange(touristSpotsFoundByCategory.Select(ts => new TouristSpotModelOut(ts)));
                }
                else
                {
                    List<TouristSpotModelOut> foundToModelOut = touristSpotsFoundByCategory.Select(ts => new TouristSpotModelOut(ts)).ToList<TouristSpotModelOut>();
                    ret = Intersect(foundToModelOut, ret);
                }
            }
            return ret;
        }

        private List<TouristSpotModelOut> Intersect(List<TouristSpotModelOut> l1, List<TouristSpotModelOut> l2)
        {
            var ids = l1.Select(x => x.Id).Intersect(l2.Select(x => x.Id));
            var result = l1.Where(x => ids.Contains(x.Id));
            return result.ToList<TouristSpotModelOut>();
        }

        private List<TouristSpotModelOut> GetByRegion(string queryString)
        {
            var value = Parse("region", queryString);
            string region = value.ElementAt<string>(0);
            List<TouristSpot> touristSpotsFoundByRegion = this.touristSpotLogic.FindByRegion(region).ToList<TouristSpot>();
            return touristSpotsFoundByRegion.Select(ts => new TouristSpotModelOut(ts)).ToList<TouristSpotModelOut>(); 
        }

        private List<string> Parse(string field, string queryString)
        {
            var parsed = HttpUtility.ParseQueryString(this.Request.QueryString.Value);
            var myFieldValues = parsed[field];
            List<string> ret = myFieldValues.Split(',').ToList<string>();
            return ret;
        }

        private List<TouristSpotModelOut> GetAll()
        {
            IEnumerable<TouristSpot> found = this.touristSpotLogic.GetAll();
            List<TouristSpotModelOut> retorno = found.Select(ts => new TouristSpotModelOut(ts)).ToList<TouristSpotModelOut>();
            return retorno;
        }
        /// <summary>
        /// Returns a TouristSpot given an Id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /touristSpots/1
        ///     {
        ///     }
        ///
        /// </remarks>
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
        /// <summary>
        /// Adds a new TouristSpot.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /touristSpots
        ///     {
        ///         "Name" : "Playa de la balconada",
        ///         "Description" : "There was an oil leak nearby"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        //[ServiceFilter(typeof(AuthorizationAttributeFilter))]
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
        /// <summary>
        /// Deletes an existing TouristSpot.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /touristSpots/1
        ///     {
        ///     }
        ///
        /// </remarks>
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
        /// <summary>
        /// Updates an existing TouristSpot.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /touristSpots/1
        ///     {
        ///         "Name" : "Playa de la balconada",
        ///         "Description" : "There was an oil leak nearby"
        ///     }
        ///
        /// </remarks>
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
