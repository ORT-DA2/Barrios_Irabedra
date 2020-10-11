using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class AccommodationLogic : IAccommodationLogic
    {
        private readonly IAccommodationRepository accommodationRepository;
        private readonly ITouristSpotLogic touristSpotLogic;

        public AccommodationLogic(IAccommodationRepository accommodationRepository, ITouristSpotLogic touristSpotLogic)
        {
            this.accommodationRepository = accommodationRepository;
            this.touristSpotLogic = touristSpotLogic;
        }

        public void Add(Accommodation accommodation, int touristSpotId)
        {
            try
            {
                var touristSpot = accommodation.TouristSpot = touristSpotLogic.Get(touristSpotId);
                accommodation.TouristSpot = touristSpot;
                accommodationRepository.Add(accommodation);
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            catch (RepeatedObjectException ex) 
            {
                throw new RepeatedObjectException();
            }
        }

        public List<AccommodationQueryOut> GetAll(AccommodationQueryIn accommodationQueryIn)
        {
            throw new NotImplementedException();
        }

        public List<AccommodationQueryOut> GetByTouristSpot(AccommodationQueryIn accommodationQueryIn)
        {
            List<AccommodationQueryOut> accommodationsToReturn = new List<AccommodationQueryOut>();
            List<Accommodation> accommodations = this.accommodationRepository.GetByTouristSpot(accommodationQueryIn.TouristSpotId);
            List<Accommodation> emptyAccommodations = new List<Accommodation>();
            foreach (var item in accommodations)
            {
                if (item.IsAvailable()) 
                {
                    emptyAccommodations.Add(item);
                }
            }
            foreach (var item in emptyAccommodations)
            {
                AccommodationQueryOut a = new AccommodationQueryOut(item);
                double totalPrice = this.CalculateTotalPrice(accommodationQueryIn, a);
                a.TotalPrice = totalPrice;
                accommodationsToReturn.Add(a);
            }
            return accommodationsToReturn;
        }

        private double CalculateTotalPrice(AccommodationQueryIn accommodationQueryIn, AccommodationQueryOut a)
        {
            int totalDays = (accommodationQueryIn.CheckOut - accommodationQueryIn.CheckIn).Days;
            double totalPrice = 
                (accommodationQueryIn.Adults*totalDays*a.PricePerNight)+
                (accommodationQueryIn.Kids * totalDays * a.PricePerNight * 0.5) +
                (accommodationQueryIn.Babies * totalDays * a.PricePerNight * 0.25);
            return totalPrice;
        }
    }
}
