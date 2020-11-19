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

        public void Add(Accommodation accommodation, string touristSpotName)
        {
            try
            {
                var touristSpot = accommodation.TouristSpot = touristSpotLogic.GetByName(touristSpotName);
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
                .GetAllAvailableByTouristSpotName(accommodationQueryIn.TouristSpotName);
            foreach (var item in accommodations)
            {
                AccommodationQueryOut a = new AccommodationQueryOut(item);
                double totalPrice = this.CalculateTotalPrice(accommodationQueryIn, a);
                a.TotalPrice = totalPrice;
                accommodationsToReturn.Add(a);
            }
            return accommodationsToReturn;
        }

        public List<AccommodationQueryOut> GetAll()
        {
            List<AccommodationQueryOut> accommodationsToReturn = new List<AccommodationQueryOut>();
            List<Accommodation> accommodations = this.accommodationRepository.GetAll();
            foreach (var item in accommodations)
            {
                AccommodationQueryOut a = new AccommodationQueryOut(item);
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
                        accommodationPutQueryIn.Name, accommodationPutQueryIn.FullCapacity);
                }
                List<ImageWrapper> imagesToAdd = new List<ImageWrapper>();
                Accommodation accommodationToUpdate = this.GetByName(accommodationPutQueryIn.Name);
                imagesToAdd = StringToImageWrapper(accommodationPutQueryIn.Images, accommodationToUpdate.Id);
                if (imagesToAdd.Count > 0)
                {
                    this.accommodationRepository.AddImages(accommodationPutQueryIn.Name, imagesToAdd);
                }
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }

        }

        private List<ImageWrapper> StringToImageWrapper(List<string> images, int id)
        {
            List<ImageWrapper> listToReturn = new List<ImageWrapper>();
            foreach (var item in images)
            {
                ImageWrapper i = new ImageWrapper
                {
                    Image = item
                };
                listToReturn.Add(i);
            }
            return listToReturn;
        }

        private double CalculateTotalPrice(AccommodationQueryIn accommodationQueryIn, AccommodationQueryOut a)
        {
            int totalDays = (accommodationQueryIn.CheckOut - accommodationQueryIn.CheckIn).Days;
            double totalPrice =
                CalculateTotalPriceForRetirees(accommodationQueryIn.Retirees, totalDays, a.PricePerNight) +
                CalculateTotatPriceForAdults(accommodationQueryIn.Adults, totalDays, a.PricePerNight) +
                CalculateTotalPriceForKids(accommodationQueryIn.Kids, a.PricePerNight, totalDays) +
                CalculateTotalPriceForBabies(accommodationQueryIn.Babies, a.PricePerNight, totalDays);
            return totalPrice;
        }

        private double CalculateTotalPriceForRetirees(double retirees, int totalDays, double pricePerNight)
        {
            int retireesWithDiscount = (int)Math.Floor((retirees/ 2));
            double retireesWithoutDiscount = retirees - retireesWithDiscount;
            double priceForRetireesWithDiscount = retireesWithDiscount * totalDays * pricePerNight * 0.7;
            double priceForRetireesWithoutDiscount = retireesWithoutDiscount * totalDays * pricePerNight;
            return (priceForRetireesWithDiscount + priceForRetireesWithoutDiscount);
        }

        private double CalculateTotalPriceForBabies(int babies, double pricePerNight, int totalDays)
        {
            return (babies * totalDays * pricePerNight * 0.25);
        }

        private double CalculateTotalPriceForKids(int kids, double pricePerNight, int totalDays)
        {
            return (kids * totalDays * pricePerNight * 0.5);
        }

        private double CalculateTotatPriceForAdults(int adults, int totalDays, double pricePerNight)
        {
            return (adults * totalDays * pricePerNight);
        }

        public void Add(Accommodation accommodation)
        {
            this.accommodationRepository.Add(accommodation);
        }

        public bool AlreadyExistsByName(string name)
        { 
                return this.accommodationRepository.AlreadyExistsByName(name);
        }

        public void Delete(string name)
        {
            this.accommodationRepository.Delete(name);
        }

        public Accommodation GetByName(string name)
        {
            return this.accommodationRepository.GetByName(name);
        }
    }
}
