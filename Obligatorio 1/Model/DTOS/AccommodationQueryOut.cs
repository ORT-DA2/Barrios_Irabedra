using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.DTOS
{
    public class AccommodationQueryOut
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public List<string> Image { get; set; }
        public string Name { get; set; }
        public double PricePerNight { get; set; }
        public double TotalPrice { get; set; }
        public int Rating { get; set; }
        
        public AccommodationQueryOut(Accommodation a)
        {
            this.Address = a.Address;
            this.Description = a.Description;
            this.Image = a.Image;
            this.Name = a.Name;
            this.PricePerNight = a.PricePerNight;
            this.Rating = a.Rating;
        }

    }
}
