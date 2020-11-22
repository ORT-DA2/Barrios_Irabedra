using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using Obligatorio.Domain.DomainEntities;
using Obligatorio.Model.Models.Out;
using System;
using System.Collections.Generic;

namespace Obligatorio.Model.DTOS
{
    public class AccommodationQueryOut
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public string Name { get; set; }
        public double PricePerNight { get; set; }
        public double TotalPrice { get; set; }
        public int Rating { get; set; }
        public List<ReviewModelOut> Reviews { get; set; }

        public AccommodationQueryOut(Accommodation a)
        {
            this.Address = a.Address;
            this.Description = a.Description;
            this.Images = UnwrapImages(a.Images);
            this.Name = a.Name;
            this.PricePerNight = a.PricePerNight;
            this.Rating = a.Rating;
            this.Reviews = WrapReviews(a.Reviews);
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

        public List<string> UnwrapImages(List<ImageWrapper> images)
        {
            List<string> imagesToReturn = new List<string>();
            foreach (var item in images)
            {
                imagesToReturn.Add(item.ToString());
            }
            return imagesToReturn;
        }

    }
}
