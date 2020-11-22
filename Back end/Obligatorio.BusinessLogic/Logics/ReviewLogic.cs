using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class ReviewLogic : IReviewLogic
    {
        private readonly IAccommodationLogic accommodationLogic;
        private readonly IReviewRepository reviewRepository;
        public void AddReview(ReviewRegistrationModelIn reviewRegistrationModelIn)
        {
            Review review = reviewRegistrationModelIn.ToEntity();
            accommodationLogic.AddReview(review);
        }
    }
}
