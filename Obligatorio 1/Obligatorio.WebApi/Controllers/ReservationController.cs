using System;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using Obligatorio.WebApi.Filters;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationLogic reservationLogic;

        public ReservationController(IReservationLogic reservationLogic)
        {
            this.reservationLogic = reservationLogic;
        }

        [HttpGet("{id}", Name = "GetReservation")]
        public IActionResult Get(int id)
        {
            try
            {
                var reservation = this.reservationLogic.Get(id);
                return Ok(new ReservationModelOut(reservation));
            }
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return NotFound("There is no such reservation id.");
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Post([FromBody] ReservationModelIn reservationModelIn)
        {
            try
            {
                var reservation = reservationModelIn.ToEntity();
                ReservationModelOut reservationToReturn = new ReservationModelOut(
                    this.reservationLogic.Add(reservation, reservationModelIn.AccommodationId));
                return Ok(reservationToReturn);
            }
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return NotFound("There is no such accommodation id.");
            }
            catch (Exception e) 
            {
                return StatusCode(500, "The Accommodation Is Full.");
            }
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Put(int id, [FromBody] ReservationPutModelIn reservationPutModelIn)
        {
            try
            {
                Reservation reservationToUpdate = reservationPutModelIn.ToEntity(id);
                this.reservationLogic.Update(reservationToUpdate);
                return Ok(this.reservationLogic.Get(id));
            }
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return NotFound("There is no reservation with such id.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
