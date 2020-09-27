
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Models.Out
{
    public class TouristSpotModel
    {
        public string Name { private set; get; }
        public string Description { private set; get; }
        public string Image { private set; get; }
        public int Id { private set; get; }

        public TouristSpotModel(TouristSpot touristSpot)
        {
            this.Description = touristSpot.Description;
            this.Name = touristSpot.Name;
            this.Image = touristSpot.Image;
            this.Id = touristSpot.Id;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TouristSpotModel touristSpot)
            {
                result = this.Id == touristSpot.Id & this.Name.Equals(touristSpot.Name);
            }
            return result;
        }

        public TouristSpot ToEntity()
        {
            return new TouristSpot()
            {
                Description = this.Description,
                Name = this.Name,
                Image = this.Image,
                Id = this.Id,
                Region = new Region(),
                //Category = new Category(),
            };
        }
    }
}
