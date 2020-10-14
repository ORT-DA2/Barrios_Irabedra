using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
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

        public AccommodationQueryOut(Accommodation a)
        {
            this.Address = a.Address;
            this.Description = a.Description;
            this.Images = UnwrapImages(a.Images);
            this.Name = a.Name;
            this.PricePerNight = a.PricePerNight;
            this.Rating = a.Rating;
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
