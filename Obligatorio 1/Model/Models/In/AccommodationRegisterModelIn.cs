using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.In
{
    public class AccommodationRegisterModelIn
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<string> Image { get; set; }
        public double PricePerNight { get; set; }
        public bool FullCapacity { get; set; }
        public string TouristSpotName { get; set; }


    }
}
