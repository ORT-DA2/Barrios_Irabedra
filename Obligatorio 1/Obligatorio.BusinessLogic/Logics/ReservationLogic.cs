using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.Domain.DomainEntities;
using System;

namespace Obligatorio.BusinessLogic.Logics
{
    public class ReservationLogic : IReservationLogic
    {
        private readonly IAccommodationLogic accommodationLogic;
        private readonly IReservationRepository reservationRepository;

        public ReservationLogic(IAccommodationLogic accommodationLogic, IReservationRepository reservationRepository)
        {
            this.accommodationLogic = accommodationLogic;
            this.reservationRepository = reservationRepository;
        }

        public Reservation Add(Reservation reservation, int accommodationId)
        {
            try
            {
                Accommodation accommodationForReservation = accommodationLogic.GetById(accommodationId);
                if (!accommodationForReservation.FullCapacity)
                {
                    reservation.AccommodationForReservation = accommodationForReservation;
                    reservation.SetInfoText();
                    reservation.SetPhoneNumber();
                    return reservationRepository.Add(reservation);
                }
                else
                {
                    throw new Exception(); //ver bien cual usar
                }
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Reservation Get(int id)
        {
            try
            {
                return this.reservationRepository.GetById(id);
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            
        }
    }
}
