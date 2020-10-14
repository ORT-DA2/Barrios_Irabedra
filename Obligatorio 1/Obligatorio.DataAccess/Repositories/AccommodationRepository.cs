using Microsoft.EntityFrameworkCore;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio.DataAccess.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<Accommodation> accommodations;

        public AccommodationRepository(DbContext context)
        {
            this.myContext = context;
            this.accommodations = context.Set<Accommodation>();
        }

        public void Add(Accommodation accommodation)
        {
            if (AlredyExisting(accommodation))
            {
                throw new RepeatedObjectException();
            }
            else
            {
                this.accommodations.Add(accommodation);
                myContext.SaveChanges();
            }
        }

        private bool AlredyExisting(Accommodation accommodation)
        {
            List<Accommodation> accommodationsToCompare = accommodations.ToList<Accommodation>();
            foreach (var item in accommodations)
            {
                if (accommodation.Name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Accommodation> GetAll()
        {
            return this.accommodations.ToList();
        }

        public List<Accommodation> GetByTouristSpot(int touristSpotId)
        {
            List<Accommodation> totalAccommodations = this.accommodations.ToList();
            foreach (var item in totalAccommodations)
            {
                myContext.Entry(item).Reference(a => a.TouristSpot).Load();
            }
            List<Accommodation> accommodationsToReturn = new List<Accommodation>();
            foreach (var item in totalAccommodations)
            {
                if (item.TouristSpot.Id.Equals(touristSpotId))
                {
                    accommodationsToReturn.Add(item);
                }
            }
            return accommodationsToReturn;
        }

        public void UpdateCapacity(int accommodationId, bool fullCapacity)
        {
            try
            {
                Accommodation accommodationToUpdate = this.GetById(accommodationId);
                accommodationToUpdate.FullCapacity = fullCapacity;
                myContext.SaveChanges();
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }

        }

        public void AddImages(int accommodationId, List<ImageWrapper> images)
        {
            try
            {
                Accommodation accommodationToUpdate = this.GetById(accommodationId);
                accommodationToUpdate.Images.AddRange(images);
            }
            catch (ObjectNotFoundInDatabaseException e)
            {

                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public Accommodation GetById(int accommodationId)
        {
            var accommodation = accommodations.Find(accommodationId);
            if(accommodation is null) 
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return accommodation;
        }
    }
}
