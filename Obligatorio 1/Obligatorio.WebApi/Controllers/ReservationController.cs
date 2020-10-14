using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;

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

        //api/reservations/5
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
        public IActionResult Post([FromBody] ReservationModelIn reservationModelIn)
        {
            try
            {
                var reservation = reservationModelIn.ToEntity();
                ReservationModelOut reservationToReturn = new ReservationModelOut(this.reservationLogic.Add(reservation, reservationModelIn.AccommodationId));
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

    }
}
