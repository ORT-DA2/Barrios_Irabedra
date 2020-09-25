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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TouristSpot Get(int id)
        {
            throw new NotImplementedException();
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
