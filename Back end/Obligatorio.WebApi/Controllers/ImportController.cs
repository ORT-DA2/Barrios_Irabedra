using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.ImportLogic.CustomExceptions;
using Obligatorio.ImportLogicInterface.Interfaces;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/imports")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportLogic importLogic;

        public ImportController(IImportLogic importLogic)
        {
            this.importLogic = importLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.importLogic.GetImplementationNames());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Imports the content of an xml/json file given its route specified in the request's body and the format
        /// in the request's route data.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /imports/xml
        ///     {
        ///         {
        ///             ...accommodationdata
        ///         }
        ///     }
        ///
        /// </remarks>
        [HttpPost("{format}")]
        public IActionResult Post([FromBody] string path, string format)
        {
            if (validFormat(format))
            {
                try
                {
                    if (this.importLogic.Import(path, format))
                    {
                        return Ok();
                    }
                }
                catch (FileIsNotJsonException)
                {
                    return BadRequest("The file was specified to be a Json but it was not.");
                }
                catch (FileNotFoundException)
                {
                    return BadRequest("The file's path could not be found.");
                }
                catch (NullReferenceException)
                {
                    return BadRequest("Empty files are not supported.");
                }
                catch (InvalidOperationException)
                {
                    return BadRequest("When specified XML files, empty files are not supported. Nonempty files must be in XML format.");
                }
            }
            return BadRequest("File format must be specified either as an XML or JSON.");
        }

        private bool validFormat(string format)
        {
            return format.ToLower().Equals("xml") || format.ToLower().Equals("json");
        }
    }
}