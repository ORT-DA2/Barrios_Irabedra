using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using System;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogic.Logics
{
    public class AccommodationLogic : IAccommodationLogic
    {
        private readonly IAccommodationRepository accommodationRepository;
        private readonly ITouristSpotLogic touristSpotLogic;

        public AccommodationLogic(IAccommodationRepository accommodationRepository
            , ITouristSpotLogic touristSpotLogic)
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
            catch(Exception e) 
            { 
            }
        }



        public Accommodation GetById(int accommodationId)
        {
            try
            {
                return this.accommodationRepository.GetById(accommodationId);
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }

        }

        public List<AccommodationQueryOut> GetByTouristSpot(AccommodationQueryIn accommodationQueryIn)
        {
            List<AccommodationQueryOut> accommodationsToReturn = new List<AccommodationQueryOut>();
            List<Accommodation> accommodations = this.accommodationRepository
                .GetByTouristSpot(accommodationQueryIn.TouristSpotId);
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

        public void Update(AccommodationPutQueryIn accommodationPutQueryIn)
        {
            try
            {
                if (accommodationPutQueryIn.ChangeCapacity)
                {
                    this.accommodationRepository.UpdateCapacity(
                        accommodationPutQueryIn.AccommodationId, accommodationPutQueryIn.FullCapacity);
                }
                List<ImageWrapper> imagesToAdd = new List<ImageWrapper>();
                imagesToAdd = StringToImageWrapper(accommodationPutQueryIn.Images);
                if (imagesToAdd.Count > 0)
                {
                    this.accommodationRepository.AddImages(accommodationPutQueryIn.AccommodationId, imagesToAdd);
                }
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }

        }

        private List<ImageWrapper> StringToImageWrapper(List<string> images)
        {
            List<ImageWrapper> listToReturn = new List<ImageWrapper>();
            foreach (var item in images)
            {
                ImageWrapper i = new ImageWrapper(item);
                listToReturn.Add(i);
            }
            return listToReturn;
        }

        private double CalculateTotalPrice(AccommodationQueryIn accommodationQueryIn, AccommodationQueryOut a)
        {
            int totalDays = (accommodationQueryIn.CheckOut - accommodationQueryIn.CheckIn).Days;
            double totalPrice =
                (accommodationQueryIn.Adults * totalDays * a.PricePerNight) +
                (accommodationQueryIn.Kids * totalDays * a.PricePerNight * 0.5) +
                (accommodationQueryIn.Babies * totalDays * a.PricePerNight * 0.25);
            return totalPrice;
        }

        public void Add(Accommodation accommodation)
        {
            this.accommodationRepository.Add(accommodation);
        }

        public bool AlreadyExistsByName(string name)
        { 
                return this.accommodationRepository.AlreadyExistsByName(name);
        }

       
    }
}
