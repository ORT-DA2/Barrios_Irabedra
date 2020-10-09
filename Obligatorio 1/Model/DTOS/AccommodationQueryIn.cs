﻿using Obligatorio.Model.Models.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.Model.Dtos
{
    public class AccommodationQueryIn
    {
        public string TouristSpotName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CantTotalHuespedes { get; set; }
        public int Babies { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }

        public AccommodationQueryIn(AccommodationModelIn accommodationModelIn)
        {
            this.TouristSpotName = accommodationModelIn.TouristSpotName;
            this.CheckIn = accommodationModelIn.CheckIn;
            this.CheckOut = accommodationModelIn.CheckOut;
            this.CantTotalHuespedes = accommodationModelIn.CantTotalHuespedes;
            this.Babies = accommodationModelIn.Babies;
            this.Kids = accommodationModelIn.Kids;
            this.Adults = accommodationModelIn.Adults;
        }
    }
}
