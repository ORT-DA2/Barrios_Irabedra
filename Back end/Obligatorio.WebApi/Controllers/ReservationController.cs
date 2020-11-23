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
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
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
                return NotFound("There is no such reservation code.");
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
        ///         "Retirees" : 3,
        ///         "CheckIn" : "2020-10-13T23:28:56.782Z",
        ///         "CheckOut" : "2020-11-01T23:28:56.782Z",
        ///         "GuestName" : "Jose",
        ///         "GuestLastName": "Perez",
        ///         "Email" : "Jose@gmail.com",
        ///         "AccommodationName" : "Hotel del mar"
        ///     }
        ///
        /// </remarks>
        /// <param name="reservationModelIn"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Post([FromBody] ReservationModelIn reservationModelIn)
        {
            try
            {
                int tot = reservationModelIn.Babies + reservationModelIn.Kids
                        + reservationModelIn.Adults + reservationModelIn.Retirees;
                var reservation = reservationModelIn.ToEntity();
                ReservationModelOut reservationToReturn = new ReservationModelOut(
                    this.reservationLogic.Add(reservation, reservationModelIn.AccommodationName));
                return Ok(reservationToReturn.UnicCode);
            }
            catch (ObjectNotFoundInDatabaseException ex)
            {
                return NotFound("There is no such accommodation Name.");
            }
            catch (ArgumentOutOfRangeException a)
            {
                return BadRequest("Error Input data not valid.");
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
        /// <param name="id"></param>
        /// <param name="reservationPutModelIn"></param>
        /// <returns></returns>
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
