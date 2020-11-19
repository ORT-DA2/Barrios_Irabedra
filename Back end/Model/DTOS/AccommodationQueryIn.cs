using Obligatorio.Model.Models.In;
using System;

namespace Obligatorio.Model.Dtos
{
    public class AccommodationQueryIn
    {
        public string TouristSpotName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TotalGuests { get; set; }
        public int Babies { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }
        public int Retirees { get; set; }

        public AccommodationQueryIn()
        {
        }

        public AccommodationQueryIn(AccommodationModelIn accommodationModelIn)
        {
            this.TouristSpotName = accommodationModelIn.TouristSpotName;
            this.CheckIn = accommodationModelIn.CheckIn;
            this.CheckOut = accommodationModelIn.CheckOut;
            this.TotalGuests = accommodationModelIn.TotalGuests;
            this.Babies = accommodationModelIn.Babies;
            this.Kids = accommodationModelIn.Kids;
            this.Adults = accommodationModelIn.Adults;
            this.Retirees = accommodationModelIn.Retirees;
        }
    }
}
