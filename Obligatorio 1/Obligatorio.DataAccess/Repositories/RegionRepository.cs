using Microsoft.EntityFrameworkCore;
using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;

namespace Obligatorio.DataAccess.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DbSet<Region> regions;
        private readonly DbContext myContext;
        private readonly ITouristSpotRepository touristSpotRepository;
        public RegionRepository(DbContext context, ITouristSpotRepository touristSpotRepository)
        {
            this.myContext = context;
            this.regions = context.Set<Region>();
            this.touristSpotRepository = touristSpotRepository;
        }
        public void Add(Region newEntity)
        {
            if (AlreadyExistsByName(newEntity))
            {
                throw new RepeatedObjectException();
            }
            else
            {
                regions.Add(newEntity);
                myContext.SaveChanges();
            }
        }

        private bool AlreadyExistsByName(Region newEntity)
        {
            foreach (var r in this.regions)
            {
                if (r.Name == newEntity.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Region Get(int id)
        {
            var region = regions.Find(id);
            if (region is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return region;
        }

        public Region Get(string name)
        {
            var region = Find(name);
            if (region is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return region;
        }

        private Region Find(string name)
        {
            foreach (var item in this.regions)
            {
                if (item.Name.Equals(name))
                {
                    return item;
                }
            }
            return null;
        }

        public IEnumerable<Region> GetAll()
        {
            return this.regions;
        }

        public IEnumerable<Region> GetAllByCondition(Func<Region, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Region newEntity)
        {
            throw new NotImplementedException();
        }

        public void AddTouristSpotToRegion(string regionName, int touristSpotId)
        {
            try
            {
                Region region = ValidateExistingRegion(regionName);
                TouristSpot touristSpot = ValidateExistingTouristSpot(touristSpotId);
                this.ThereIsRegionWithThisTouristSpot(touristSpot);
                region.TouristSpots.Add(touristSpot);
                regions.Update(region);
                myContext.SaveChanges();
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            catch (RepeatedObjectException)
            {
                throw new RepeatedObjectException();
            }

        }

        private TouristSpot ValidateExistingTouristSpot(int touristSpotId)
        {
            var touristSpot = this.touristSpotRepository.Get(touristSpotId);
            if (touristSpot is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return touristSpot;
        }

        private Region ValidateExistingRegion(string regionName)
        {
            var region = this.Find(regionName);
            if (region is null)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
            return region;
        }

        private void ThereIsRegionWithThisTouristSpot(TouristSpot touristSpot)
        {
            foreach (var r in regions)
            {
                if ((r.TouristSpots is null)
                || (r.TouristSpots.Contains(touristSpot)))
                {
                    throw new RepeatedObjectException();
                }
            }
        }
    }
}