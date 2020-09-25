using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Out
{
    public class TouristSpotBasicInfoModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; } 
        public int Id { get; set; }

        public TouristSpotBasicInfoModel(TouristSpot touristSpot)
        {
            this.Description = touristSpot.Description;
            this.Name = touristSpot.Name;
            this.Image = touristSpot.Image;
            this.Id = touristSpot.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is TouristSpotBasicInfoModel model &&
                   Name == model.Name &&
                   Id == model.Id;
        }
    }
}
