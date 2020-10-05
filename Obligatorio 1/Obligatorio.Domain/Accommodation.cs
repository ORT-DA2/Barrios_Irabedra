﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int PricePerNight { get; set; }
        public bool FullCapacity { get; set; }
        public TouristSpot TouristSpot { get; set; }

        public Accommodation()
        {
            this.Name = "Default Name";
            this.Rating = -1;
            this.Adress = "Default Adress";
            this.Description = "Default Description";
            this.Image = "Default Image";
            this.PricePerNight = -1;
            this.FullCapacity = false;
        }

        public bool IsAvailable() 
        {
            return !this.FullCapacity;
        }

    }
}
