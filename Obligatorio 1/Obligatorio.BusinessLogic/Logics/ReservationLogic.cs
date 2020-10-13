using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;

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
    }
}
