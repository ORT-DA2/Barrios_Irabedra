using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [EnableCors("AllowAngularFrontEndClientApp")]
    [Route("api/reports")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportLogic reportLogic;

        public ReportController(IReportLogic reportLogic)
        {
            this.reportLogic = reportLogic;
        }

        /// <summary>
        /// Get the report in base of the query string.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Get()
        {
            var queryString = HttpUtility.ParseQueryString(this.HttpContext.Request.QueryString.Value);
            if (queryString.Count == 0)
            {
                return BadRequest("Information needed.");
            }
            else
            {
                try
                {
                    ReportModelIn reportModelIn = new ReportModelIn
                    {
                        TouristSpotName = queryString.Get("touristSpotName"),
                        EndDate = new DateTime(
                             Int32.Parse(queryString.Get("endDateYear")),
                             Int32.Parse(queryString.Get("endDateMonth")),
                             Int32.Parse(queryString.Get("endDateDay"))
                            ),
                        StartDate = new DateTime(
                             Int32.Parse(queryString.Get("startDateYear")),
                             Int32.Parse(queryString.Get("startDateMonth")),
                             Int32.Parse(queryString.Get("startDateDay"))
                            )
                    };
                    List<ReportLineModelOut> reports = new List<ReportLineModelOut>() ;
                    reports = reportLogic.GetReports(reportModelIn);
                    return Ok(reports);
                }
                catch (Exception e)
                {
                    return BadRequest("Wrong input: incorrect query string");
                }
            }

        }
    }
}
