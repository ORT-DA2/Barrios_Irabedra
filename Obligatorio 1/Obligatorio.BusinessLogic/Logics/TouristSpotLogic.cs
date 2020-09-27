﻿using Obligatorio.BusinessLogic.CustomExceptions;
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

        public TouristSpotLogic(ITouristSpotRepository touristSpotRepository)
        {
            this.touristSpotRepository = touristSpotRepository;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(int id, TouristSpot newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
