using Obligatorio.Model.Models.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.Model.Dtos
{
    public class AccommodationQueryIn
    {
        public int TouristSpotId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TotalGuests { get; set; }
        public int Babies { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }

        public AccommodationQueryIn(AccommodationModelIn accommodationModelIn)
        {
            this.TouristSpotId = accommodationModelIn.TouristSpotId;
            this.CheckIn = accommodationModelIn.CheckIn;
            this.CheckOut = accommodationModelIn.CheckOut;
            this.TotalGuests = accommodationModelIn.TotalGuests;
            this.Babies = accommodationModelIn.Babies;
            this.Kids = accommodationModelIn.Kids;
            this.Adults = accommodationModelIn.Adults;
        }
    }
}
