
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Models.In
{
    public class TouristSpotModelIn
    {
        public string Name { set; get; }
        public string Description {  set; get; }
        public string Image {set; get; }
        public int Id {  set; get; }

        public TouristSpotModelIn(TouristSpot touristSpot)
        {
            this.Description = touristSpot.Description;
            this.Name = touristSpot.Name;
            this.Image = touristSpot.Image;
            this.Id = touristSpot.Id;
        }

        public TouristSpotModelIn()
        {
            Name = "Default Name";
            Description = "Default Description";
            Image = "Default Image";
        }

        public TouristSpot ToEntity()
        {
            TouristSpot ret = new TouristSpot
            {
                Description = this.Description,
                Name = this.Name,
                Image = this.Image,
                Region = new Region(),
            };
            return ret;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TouristSpotModelIn touristSpot)
            {
                result = this.Name.Equals(touristSpot.Name);
            }
            return result;
        }

    
    }
}
