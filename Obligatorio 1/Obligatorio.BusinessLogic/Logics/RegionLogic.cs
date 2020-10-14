using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogic.Logics
{
    public class RegionLogic : IRegionLogic
    {
        private readonly IRegionRepository regionRepository;

        public RegionLogic(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public void Add(Region newEntity)
        {
            if (newEntity.Validate())
            {
                try
                {
                    this.regionRepository.Add(newEntity);
                }
                catch (RepeatedObjectException ex)
                {
                    throw new RepeatedObjectException();
                }
            }
        }

        public void AddTouristSpotToRegion(string regionName, int touristSpotId)
        {
            try
            {
                this.regionRepository.AddTouristSpotToRegion(regionName, touristSpotId);
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

        public Region Get(int id)
        {
            try
            {
                return this.regionRepository.Get(id);
            }
            catch (Exception ex)
            {

                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public Region Get(string name)
        {
            try
            {
                return this.regionRepository.Get(name);
            }
            catch (Exception)
            {

                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public IEnumerable<Region> GetAll()
        {
            return this.regionRepository.GetAll();
        }

        public void ModifyTouristSpotRegion(string regionName, int touristSpotId)
        {
            try
            {
                this.regionRepository.ModifyTouristSpotRegion(regionName, touristSpotId);
            }
            catch (ObjectNotFoundInDatabaseException)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
        }
    }
}