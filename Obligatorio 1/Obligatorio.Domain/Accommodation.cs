using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Domain
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<string> Image { get; set; }
        public double PricePerNight { get; set; }
        public bool FullCapacity { get; set; }
        public TouristSpot TouristSpot { get; set; }

        public Accommodation()
        {
            this.Name = "Default Name";
            this.Rating = -1;
            this.Address = "Default Address";
            this.Description = "Default Description";
            this.Image = new List<string>();
            this.PricePerNight = -1;
            this.FullCapacity = false;
        }

        public bool IsAvailable() 
        {
            return !this.FullCapacity;
        }

    }
}
