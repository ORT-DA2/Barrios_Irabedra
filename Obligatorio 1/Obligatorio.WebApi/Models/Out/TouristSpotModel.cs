
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Out
{
    public class TouristSpotModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        [Required]
        public int Id { get; set; }

        public TouristSpotModel(TouristSpot touristSpot)
        {
            this.Description = touristSpot.Description;
            this.Name = touristSpot.Name;
            this.Image = touristSpot.Image;
            this.Id = touristSpot.Id;
        }

        public TouristSpotModel()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is TouristSpotModel model &&
                   Name == model.Name &&
                   Id == model.Id;
        }
    }
}
