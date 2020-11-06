using Obligatorio.Domain;
using Obligatorio.Domain.AuxiliaryObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.ExternalFileImport.Models
{
    public class AccommodationImportModel
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double PricePerNight { get; set; }
        public bool FullCapacity { get; set; }
        public TouristSpotImportModel TouristSpot { get; set; }

        public AccommodationImportModel()
        {

        }

        public Accommodation ToEntity()
        {
            return new Accommodation()
            {
                Images = new List<ImageWrapper>() { new ImageWrapper(this.Image) },
                Name = this.Name,
                Address = this.Address,
                Rating = this.Rating,
                PricePerNight = this.PricePerNight,
                FullCapacity = this.FullCapacity,
                Description = this.Description,
                TouristSpot = null,
            };
        }
    }
}

