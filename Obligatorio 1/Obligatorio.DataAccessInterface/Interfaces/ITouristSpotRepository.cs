using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ITouristSpotRepository
    {
        IEnumerable<TouristSpot> GetAll();
    }
}
