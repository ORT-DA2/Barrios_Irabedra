using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain
{
    public class TouristSpotCategory
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public TouristSpot TouristSpot { get; set; }
        public int TouristSpotId { get; set; }

        public TouristSpotCategory()
        {
        }
    }
}
