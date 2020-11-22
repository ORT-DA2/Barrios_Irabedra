using Microsoft.EntityFrameworkCore;
using Obligatorio.DataAccessInterface.Interfaces;
using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio.DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DbContext context;
        private readonly DbSet<Review> reviews;

        public ReviewRepository(DbContext context)
        {
            this.context = context;
            this.reviews = context.Set<Review>();
        }

        public List<Review> GetByAccommodationName(string accommodationName)
        {
            List<Review> reviewsToReturn = this.reviews.ToList();
            foreach (var review in reviewsToReturn)
            {
                if (review.Name.Equals(accommodationName)) 
                {
                    reviewsToReturn.Add(review);
                }
            }
            return reviewsToReturn;
        }
    }
}
