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

        public AccommodationLogic(IAccommodationRepository accommodationRepository)
        {
            this.accommodationRepository = accommodationRepository;
        }

        public List<AccommodationQueryOut> GetAll(AccommodationQueryIn accommodationQueryIn)
        {
            throw new NotImplementedException();
        }

        public List<AccommodationQueryOut> GetByTouristSpot(AccommodationQueryIn accommodationQueryIn)
        {
            List<AccommodationQueryOut> accommodationsToReturn = new List<AccommodationQueryOut>();
            List<Accommodation> accommodations = this.accommodationRepository.GetByTouristSpot(accommodationQueryIn.TouristSpotName);
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
