using System;
using Microsoft.AspNetCore.Mvc;
using Model.Models.In;
using Model.Models.Out;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.WebApi.AuxiliaryObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryLogic categoryLogic;

        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }
        // GET: api/categories
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.categoryLogic.GetAll());
        }

        [HttpGet("{name}", Name = "GetCategory")]
        public IActionResult Get(string name)
        {
            if (name.Contains(" "))
            {
                return BadRequest("URIs should not contain blank spaces.");
            }
            string nameWithSpaces = name.Replace('_', ' ');
            try
            {
                var category = this.categoryLogic.Get(nameWithSpaces);
                return Ok(new CategoryModelOut(category));
            }
            catch (Exception ex)
            {
                return NotFound("There is no such category name.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryModelIn categoryModel)
        {
            try
            {
                var category = categoryModel.ToEntity();
                this.categoryLogic.Add(category);
                return CreatedAtRoute(routeName: "GetCategory",
                                                    routeValues: new { name = categoryModel.Name },
                                                        value: new CategoryModelIn(category));
            }
            catch (Exception ex)
            {
                return BadRequest("A region with such name has been already registered.");
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CategoryAndTouristSpotIdentifier data)
        {
            try
            {
                this.categoryLogic.AddTouristSpotToCategory(data.CategoryName, data.TouristSpotId);
                return Ok("Updated");
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                return NotFound("Either there is no such category in our database, or there is no such tourist spot id.");
            }
            catch (InvalidCastException)
            {
                return BadRequest("The input format is not correct.");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
