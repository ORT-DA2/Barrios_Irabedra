using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewLogic reviewLogic;
        public ReviewController(IReviewLogic reviewLogic)
        {
            this.reviewLogic = reviewLogic;
        }
        /// <summary>
        /// Create a Review.
        /// </summary>
        /// <param name="reviewRegistrationModelIn"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ReviewRegistrationModelIn reviewRegistrationModelIn)
        {
            try
            {
                reviewLogic.AddReview(reviewRegistrationModelIn);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("The accommodation name was not found");
            }
        }
        /// <summary>
        /// Get a Review.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var queryString = HttpUtility.ParseQueryString(this.HttpContext.Request.QueryString.Value);
            if (queryString.Count == 0)
            {
                return BadRequest("Accommodation Name Required");
            }
            string accommodationName = queryString.Get("name");
            List<ReviewModelOut> reviewModelOuts = reviewLogic.GetReviewByAccommodationName(accommodationName);
            return Ok(reviewModelOuts);
        }
    }
}
