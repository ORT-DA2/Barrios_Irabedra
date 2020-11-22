using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.In
{
    public class ReviewRegistrationModelIn
    {
        public string Text { get; set; }
        public string AcccommodationName { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ReviewRegistrationModelIn() 
        { 
        }

        public Review ToEntity()
        {
            Review review = new Review();
            review.Name = this.Name;
            review.Text = this.Text;
            review.Rating = this.Rating;
            review.AcccommodationName = this.AcccommodationName;
            review.LastName = this.LastName;
            return review;
        }
    }
}
