using System;
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
            if(Request.QueryString.Value is null) 
            {
                return Ok(this.touristSpotLogic.GetAll().Select(ts => new TouristSpotModelOut(ts)));
            }
            else
            {
                IEnumerable<TouristSpotModelOut> touristSpots = new List<TouristSpotModelOut>();
                string arguments = Request.QueryString.Value.Split('?')[1];  //categoryName=%22Nautico%22&categoryName=%22Malls%22
                List<string> criteria = arguments.Split('&').ToList<String>(); //categoryName=%22Nautico%22
                foreach (var param in criteria)
                {
                    string value = param.Split('=')[1].Replace("%22", "");
                    value = value.Replace("%20", " ");
                    IEnumerable<TouristSpotModelOut> list = this.touristSpotLogic.FindByCategory(value).Select(ts => new TouristSpotModelOut(ts));
                    touristSpots.Concat(list);
                }
                touristSpots = touristSpots.Distinct<TouristSpotModelOut>().ToList();
                return Ok(touristSpots);
            }
        }

        //api/touristSpots
        //[HttpGet("{queryString}/{queryString2}")]
        //[Route("filter{queryString}")]
        /*public IActionResult Filter(string queryString, string queryString2) //?categoryName="Nautica"&categoryName="Playas"
        {
            queryString2 = queryString2.Split('?')[1];
            string[] queryParams = queryString2.Split('&');
            List<string> queryParamList = queryParams.ToList<string>();
            List<string> paramValues = new List<string>();
            foreach (var item in queryParamList)
            {
                paramValues.Add(item.Split('=')[1].Replace('"', ' ').Trim());
            }
            List<TouristSpotModelOut> touristSpots = new List<TouristSpotModelOut>();
            foreach (var value in paramValues)
            {
                touristSpots.AddRange(this.touristSpotLogic.FindByCategory(value).Select(ts => new TouristSpotModelOut(ts)));
            }
            touristSpots = touristSpots.Distinct<TouristSpotModelOut>().ToList();
            return Ok(touristSpots);
        }*/
        
        
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
