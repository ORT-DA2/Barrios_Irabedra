using Obligatorio.Domain;
using Obligatorio.Model.Dtos;
using Obligatorio.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IAccommodationLogic
    {
        List<AccommodationQueryOut> GetAll(AccommodationQueryIn accommodationQueryIn);
        List<AccommodationQueryOut> GetByTouristSpot(AccommodationQueryIn accommodationQueryIn);
        void Add(Accommodation accommodation, int touristSpotId);
    }
}
