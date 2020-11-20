using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class ReportLogic : IReportLogic
    {
        private readonly ITouristSpotLogic touristSpotLogic;
        private readonly IAccommodationLogic accommodationLogic;
        private readonly IReservationLogic reservationLogic;

        public ReportLogic(ITouristSpotLogic touristSpotLogic, IAccommodationLogic accommodationLogic, 
            IReservationLogic reservationLogic)
        {
            this.touristSpotLogic = touristSpotLogic;
            this.accommodationLogic = accommodationLogic;
            this.reservationLogic = reservationLogic;
        }

        public List<ReportLineModelOut> GetReports(ReportModelIn reportModelIn)
        {
            List<Accommodation> accommodations = this.accommodationLogic.GetAllByTouristSpotName(reportModelIn.TouristSpotName);
            List<Reservation> reservations = this.reservationLogic.GetAll();
            List<ReportLineModelOut> reportsToReturn = new List<ReportLineModelOut>();

            foreach (Accommodation accommodation in accommodations)
            {
                ReportLineModelOut reporte = this.GetReportLineForAccommodation(accommodation, reservations, reportModelIn);
                if (reporte != null)
                {
                    reportsToReturn.Add(reporte);
                }
            }
            var reportsOrderByDescendingResult = from r in reportsToReturn
                                                 orderby r.Reservations, r.Id descending
                                                 select r;
            return reportsOrderByDescendingResult.ToList<ReportLineModelOut>();
        }

        private ReportLineModelOut GetReportLineForAccommodation(Accommodation accommodation, List<Reservation> reservations, ReportModelIn reportModelIn)
        {
            ReportLineModelOut reportToReturn = new ReportLineModelOut (accommodation.Name, accommodation.Id);
            foreach (var reservation in reservations)
            {
                if (MatchesRequirementsForReservation(accommodation, reservation, reportModelIn))
                {
                    reportToReturn.Reservations++;
                }
            }
            if (reportToReturn.Reservations == 0)
            {
                return null;
            }
            return reportToReturn;
        }

        private bool MatchesRequirementsForReservation(Accommodation accommodation, Reservation reservation, ReportModelIn reportModelIn)
        {
            return MatchesName(reservation, accommodation) && reservation.ReservationSatusQualifiesForReport() && DatesMatch(reportModelIn, reservation);
        }

        private bool DatesMatch(ReportModelIn reportModelIn, Reservation reservation)
        {
            bool matches = false;
            if (IsWithinBound(reportModelIn, reservation))
            {
                matches = true;
            }

            return matches;
        }

        private bool IsWithinBound(ReportModelIn reportModelIn, Reservation reservation)
        {
            bool match = false;
            if ((reportModelIn.StartDate <= reservation.CheckOut) && (reportModelIn.EndDate>=reservation.CheckIn))
            {
                match = true;
            }
            return match;
        }

        private bool MatchesName(Reservation reservation, Accommodation accommodation)
        {
            return reservation.AccommodationForReservation.Name == accommodation.Name;
        }

    }
}
