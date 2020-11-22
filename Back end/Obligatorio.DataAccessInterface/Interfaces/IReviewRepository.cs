using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IReviewRepository
    {
        List<Review> GetByAccommodationName(string accommodationName);
    }
}
