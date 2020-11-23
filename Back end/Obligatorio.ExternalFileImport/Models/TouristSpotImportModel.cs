
using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.ExternalFileImport.Models
{
    public class TouristSpotImportModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public string RegionName { set; get; }

        public TouristSpotImportModel()
        {

        }

        public TouristSpot ToEntity()
        {
            return (new TouristSpot()
            {
                Name = this.Name,
                Description = this.Description,
                Image = this.Image,
                TouristSpotCategories = new List<TouristSpotCategory>(),
            }); ;
        }
    }

}
