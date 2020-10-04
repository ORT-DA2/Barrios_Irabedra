using Obligatorio.BusinessLogic.CustomExceptions;
using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain;
using System;
using System.Collections.Generic;

namespace Obligatorio.BusinessLogic.Logics
{
    public class TouristSpotLogic : ITouristSpotLogic
    {
       private readonly ITouristSpotRepository touristSpotRepository;
       private readonly ITouristSpotCategoryLogic touristSpotCategoryLogic;

        public TouristSpotLogic(ITouristSpotRepository touristSpotRepository, ITouristSpotCategoryLogic touristSpotCategoryLogic)
        {
            this.touristSpotRepository = touristSpotRepository;
            this.touristSpotCategoryLogic = touristSpotCategoryLogic;
        }

        public void Add(TouristSpot newEntity)
        {
            if (newEntity.Validate())
            {
                try
                {
                    this.touristSpotRepository.Add(newEntity);
                }
                catch(RepeatedObjectException ex)
                {
                    throw new RepeatedObjectException();
                }
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.touristSpotRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public IEnumerable<TouristSpot> FindByCategory(string value)
        {
            return this.touristSpotCategoryLogic.FindByCategory(value);
        }

        public TouristSpot Get(int id)
        {
            try
            {
                return this.touristSpotRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
        }

        public IEnumerable<TouristSpot> GetAll()
        {
            return this.touristSpotRepository.GetAll();
        }

        public IEnumerable<TouristSpot> GetAllByCondition(Func<TouristSpot, bool> predicate)
        {
            return this.touristSpotRepository.GetAllByCondition(predicate);
        }

        public void Update(int id, TouristSpot newEntity)
        {
            try
            {
                this.touristSpotRepository.Update(id, newEntity);
            }
            catch (Exception ex)
            {
                throw new ObjectNotFoundInDatabaseException();
            }
        }
    }
}
