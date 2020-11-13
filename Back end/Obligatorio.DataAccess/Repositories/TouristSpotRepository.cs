using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccess.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio.DataAccess.Repositories
{
    public class TouristSpotRepository : ITouristSpotRepository
    {
        private readonly DbSet<TouristSpot> touristSpots;
        private readonly DbContext myContext;

        public TouristSpotRepository(DbContext context)
        {
            this.myContext = context;
            this.touristSpots = context.Set<TouristSpot>();
        }

        public IEnumerable<TouristSpot> GetAll()
        {
            return this.touristSpots;
        }

        public TouristSpot Get(int id)
        {
            var touristSpot = touristSpots.Find(id);
            if (touristSpot is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return touristSpot;
        }

        public void Add(TouristSpot newEntity)
        {
            if (AlreadyExistsByName(newEntity))
            {
                throw new RepeatedObjectException();
            }
            else
            {
                touristSpots.Add(newEntity);
                myContext.SaveChanges();
            }
        }

        private bool AlreadyExistsByName(TouristSpot newEntity)
        {
            foreach (var ts in this.touristSpots)
            {
                if (ts.Name == newEntity.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void Delete(int id)
        {
            var objectFound = this.touristSpots.Find(id);
            if (objectFound is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            else
            {
                this.touristSpots.Remove(objectFound);
                myContext.SaveChanges();
            }
        }

        public void Update(int id, TouristSpot newEntity)
        {
            var objectFound = this.touristSpots.Find(id);
            if (objectFound is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            else
            {
                UpdateEntity(objectFound, newEntity);
                myContext.Entry(objectFound).State = EntityState.Modified;
                myContext.SaveChanges();
            }
        }

        private void UpdateEntity(TouristSpot objectToUpdate, TouristSpot newData)
        {
            if (newData.Name != "Default Name")
            {
                objectToUpdate.Name = newData.Name;
            }
            if (newData.Description != "Default Description")
            {
                objectToUpdate.Description = newData.Description;
            }
            if (newData.Image != "Default Image")
            {
                objectToUpdate.Image = newData.Image;
            }
        }

        public IEnumerable<TouristSpot> GetAllByCondition(Func<TouristSpot, bool> predicate)
        {
            List<TouristSpot> touristSpotsToReturn = new List<TouristSpot>();
            foreach (var ts in this.touristSpots)
            {
                if (predicate(ts))
                {
                    touristSpotsToReturn.Add(ts);
                }
            }
            return touristSpotsToReturn;
        }

        public void Update(TouristSpot touristSpot)
        {
            myContext.SaveChanges();
        }

        public void Add(TouristSpot touristSpot, TouristSpotCategory touristSpotCategory)
        {
            touristSpot.TouristSpotCategories.Add(touristSpotCategory);
            myContext.SaveChanges();
        }

        public bool AlreadyExistsByName(string name)
        {
            var list = this.touristSpots.ToList<TouristSpot>();
            foreach (var item in list)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public TouristSpot Find(string name)
        {
            var list = this.touristSpots.ToList<TouristSpot>();
            foreach (var item in list)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    return item;
                }
            }
            throw new ObjectNotFoundInDatabaseException();
        }

        public TouristSpot Get(string touristSpotName)
        {
            var touristSpot = this.Find(touristSpotName);
            if (touristSpot is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return touristSpot;
        }

    }
}