using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IReviewLogic
    {
        void AddReview(ReviewRegistrationModelIn reviewRegistrationModelIn);
        List<ReviewModelOut> GetReviewByAccommodationName(string accommodationName);
    }
}
