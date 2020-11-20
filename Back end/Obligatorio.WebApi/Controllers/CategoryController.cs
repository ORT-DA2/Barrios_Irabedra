using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.Models.In;
using Model.Models.Out;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.WebApi.AuxiliaryObjects;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [EnableCors("AllowAngularFrontEndClientApp")]
    //[System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryLogic categoryLogic;

        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }
        /// <summary>
        /// Returns all Categories.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /categories
        ///     {
        ///     }
        ///
        /// </remarks>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.categoryLogic.GetAll());
        }
        /// <summary>
        /// Returns a category given a name.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /categories/"Malls"
        ///     {
        ///     }
        ///
        /// </remarks>
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
        /// <summary>
        /// Adds a category.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /categories
        ///     {
        ///        "Name" : "Malls"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Post([FromBody] CategoryModelIn categoryModel)
        {
            try
            {
                var category = categoryModel.ToEntity();
                this.categoryLogic.Add(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("A category with such name has been already registered.");
            }
        }
        /// <summary>
        /// Adds a TouristSpot to an existing Category.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /categories
        ///     {
        ///        "CategoryName" : "Nautical",
        ///        "TouristSpotId" : 1
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        //[ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Put([FromBody] CategoryAndTouristSpotIdentifier data)
        {
            try
            {
                this.categoryLogic.AddTouristSpotToCategory(data.CategoryName, data.TouristSpotName);
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
