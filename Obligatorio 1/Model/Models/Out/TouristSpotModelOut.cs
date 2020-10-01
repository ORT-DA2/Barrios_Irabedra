﻿
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Models.In
{
    public class TouristSpotModelOut
    {
        public string Name { private set; get; }
        public string Description { private set; get; }
        public string Image { private set; get; }
        public int Id { private set; get; }

        public TouristSpotModelOut(TouristSpot touristSpot)
        {
            this.Description = touristSpot.Description;
            this.Name = touristSpot.Name;
            this.Image = touristSpot.Image;
            this.Id = touristSpot.Id;
        }

        public TouristSpotModelOut()
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
                Id = this.Id,
                Region = new Region(),
                //Category = new Category(),
            };
            return ret;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TouristSpotModelOut touristSpot)
            {
                result = this.Id == touristSpot.Id & this.Name.Equals(touristSpot.Name);
            }
            return result;
        }

    
    }
}