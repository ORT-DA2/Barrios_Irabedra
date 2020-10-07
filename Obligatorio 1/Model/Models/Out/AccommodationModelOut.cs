using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.Out
{
    public class AccommodationModelOut
    {
        public string Adress { get; set; }
        public string Description { get; set; }
        public bool FullCapacity { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int PricePerNight { get; set; }
        public int Rating { get; set; }
        public AccommodationModelOut(Accommodation a)
        {
            this.Adress = a.Address;
            this.Description = a.Description;
            this.FullCapacity = a.FullCapacity;
            this.Id=a.Id;
            this.Image=a.Image;
            this.Name=a.Name;
            this.PricePerNight=a.PricePerNight;
            this.Rating = a.Rating;
        }



    }
}
