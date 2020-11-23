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
using Obligatorio.WebApi.AuxiliaryObjects;
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

        /// <summary>
        /// Get Implementations.
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string xmlPath, [FromHeader] string jsonPath)
        {
            try
            {
                return Ok(this.importLogic.GetImplementationNames(jsonPath, xmlPath));
            }
            catch (Exception ex)
            {
                return BadRequest("Either such directory could not be found, or the file name is not correct.");
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
        /// <param name="path"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        [HttpPost("{format}")]
        public IActionResult Post([FromBody] StringWrapper path, string format)
        {
            if (validFormat(format))
            {
                try
                {
                    if (this.importLogic.Import(path.BinaryPath, path.FilePath, format))
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
                catch (DllNotFoundException)
                {
                    return BadRequest("An error ocurred. Please check the input data.");
                }
                catch (Exception)
                {
                    return BadRequest("An error ocurred. Please check the input data.");
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