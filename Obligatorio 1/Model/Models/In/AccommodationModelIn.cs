﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.In
{
    public class AccommodationModelIn
    {
        public string TouristSpotName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CantTotalHuespedes { get; set; }
        public int Babies { get; set; }
        public int Kids { get; set; }
        public int Adults { get; set; }

        public AccommodationModelIn()
        {
        }
    }
}
