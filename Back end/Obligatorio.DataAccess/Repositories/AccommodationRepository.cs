using Microsoft.EntityFrameworkCore;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio.DataAccess.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<Accommodation> accommodations;
        private readonly DbSet<ImageWrapper> images;

        public AccommodationRepository(DbContext context)
        {
            this.myContext = context;
            this.accommodations = context.Set<Accommodation>();
            this.images = context.Set<ImageWrapper>();
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
            if (accommodation is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return accommodation;
        }

        public bool AlreadyExistsByName(string name)
        {
            var list = this.accommodations.ToList<Accommodation>();
            foreach (var item in list)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public void Delete(string name)
        {
            var list = this.accommodations.ToList<Accommodation>();
            foreach (var item in list)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    Accommodation toDelete = this.GetByName(name);
                    if (toDelete is null)
                    {
                        throw new ObjectNotFoundInDatabaseException();
                    }
                    this.myContext.Entry(toDelete).State = EntityState.Deleted;
                    this.myContext.Remove(toDelete);
                    this.myContext.SaveChanges();
                }
            }
        }

        public Accommodation GetByName(string name)
        {
            var list = this.accommodations.ToList<Accommodation>();
            foreach (var item in list)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateCapacity(string name, bool fullCapacity)
        {
            try
            {
                Accommodation accommodationToUpdate = this.GetByName(name);
                if (accommodationToUpdate is null)
                {
                    throw new Exception();
                }
                accommodationToUpdate.FullCapacity = fullCapacity;
                myContext.SaveChanges();
            }
            catch (ObjectNotFoundInDatabaseException e)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public void AddImages(string name, List<ImageWrapper> images)
        {
            try
            {
                Accommodation accommodationToUpdate = this.GetByName(name);
                var existingImages = accommodationToUpdate.Images;
                foreach (var item in images)
                {
                    existingImages.Add(item);
                    //this.images.Add(item);                
                }
                accommodationToUpdate.Images = existingImages;

                myContext.Entry(accommodationToUpdate).State = EntityState.Modified;
                myContext.SaveChanges();
            }
            catch (ObjectNotFoundInDatabaseException e)
            {

                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public List<Accommodation> GetAllAvailableByTouristSpotName(string touristSpotName)
        {
            List<Accommodation> totalAccommodations = this.accommodations.ToList();
            List<Accommodation> accommodationsToReturn = new List<Accommodation>();
            try 
            {
                foreach (var item in totalAccommodations)
                {
                    myContext.Entry(item).Reference(a => a.TouristSpot).Load();
                }
                foreach (var item in totalAccommodations)
                {
                    if (item.TouristSpot.Name.Equals(touristSpotName) && item.IsAvailable())
                    {
                        accommodationsToReturn.Add(item);
                    }
                }
                return accommodationsToReturn;
            } 
            catch (Exception e) 
            {
                return accommodationsToReturn;
            }
        }

        public List<Accommodation> GetAllByTouristSpotName(string touristSpotName)
        {
            List<Accommodation> totalAccommodations = this.accommodations.ToList();
            List<Accommodation> accommodationsToReturn = new List<Accommodation>();
            try
            {
                foreach (var item in totalAccommodations)
                {
                    myContext.Entry(item).Reference(a => a.TouristSpot).Load();
                }
                foreach (var item in totalAccommodations)
                {
                    if (item.TouristSpot.Name.Equals(touristSpotName))
                    {
                        accommodationsToReturn.Add(item);
                    }
                }
                return accommodationsToReturn;
            }
            catch (Exception e)
            {
                return accommodationsToReturn;
            }
        }
    }

}
