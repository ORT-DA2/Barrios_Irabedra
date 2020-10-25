using Obligatorio.Model.DTOS;
using System.Collections.Generic;

namespace Obligatorio.Model.Models.Out
{
    public class AccommodationModelOut
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public string Name { get; set; }
        public double PricePerNight { get; set; }
        public double TotalPrice { get; set; }
        public int Rating { get; set; }

        public AccommodationModelOut(AccommodationQueryOut a)
        {
            this.Address = a.Address;
            this.Description = a.Description;
            this.Images = a.Images;
            this.Name=a.Name;
            this.PricePerNight=a.PricePerNight;
            this.Rating = a.Rating;
            this.TotalPrice = a.TotalPrice;
        }
    }
}
