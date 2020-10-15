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
        /// <summary>
        /// Returns a reservation given an id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /reservations/1
        ///     {
        ///     }
        ///
        /// </remarks>
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
        /// <summary>
        /// Adds a new reservation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /reservations
        ///     {
        ///         "TouristSpotId" : 1,
        ///         "TotalGuests" : 4,
        ///         "Babies" : 1,
        ///         "Kids" : 1,
        ///         "Adults" : 2,
        ///         "CheckIn" : "2020-10-13T23:28:56.782Z",
        ///         "CheckOut" : "2020-11-01T23:28:56.782Z",
        ///         "GuestName" : "Jose",
        ///         "GuestLastName": "Perez",
        ///         "Email" : "Josesito@gmail.com",
        ///         "AccommodationId" : 1
        ///     }
        ///
        /// </remarks>
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
        /// <summary>
        /// Updates a reservation.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /reservations
        ///     {
        ///         "State" : 2,
        ///         "Description" : "Testing"
        ///     }
        ///
        /// </remarks>
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
