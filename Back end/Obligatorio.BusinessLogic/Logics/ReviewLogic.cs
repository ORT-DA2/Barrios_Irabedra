using Obligatorio.BusinessLogicInterface.Interfaces;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class ReviewLogic : IReviewLogic
    {
        private readonly IAccommodationLogic accommodationLogic;
        private readonly IReviewRepository reviewRepository;

        public ReviewLogic(IAccommodationLogic accommodationLogic, IReviewRepository reviewRepository)
        {
            this.accommodationLogic = accommodationLogic;
            this.reviewRepository = reviewRepository;
        }

        public void AddReview(ReviewRegistrationModelIn reviewRegistrationModelIn)
        {
            Review review = reviewRegistrationModelIn.ToEntity();
            accommodationLogic.AddReview(review);
        }

        public List<ReviewModelOut> GetReviewByAccommodationName(string accommodationName)
        {
            List<ReviewModelOut> reviewsToReturn = new List<ReviewModelOut>();
            List<Review> reviews = reviewRepository.GetByAccommodationName(accommodationName);
            reviewsToReturn = WrapReviews(reviews);
            return reviewsToReturn;
        }

        private List<ReviewModelOut> WrapReviews(List<Review> reviews)
        {
            List<ReviewModelOut> reviewsToReturn = new List<ReviewModelOut>();
            foreach (var review in reviews)
            {
                ReviewModelOut reviewToAdd = new ReviewModelOut()
                {
                    AcccommodationName = review.AcccommodationName,
                    LastName = review.LastName,
                    Name = review.Name,
                    Rating = review.Rating,
                    Text = review.Text
                };
                reviewsToReturn.Add(reviewToAdd);
            }
            return reviewsToReturn;
        }
    }
}
