
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
        public string Image { set; get; } //stringbase64
        /*public TouristSpotImportModel(string data)
        {
            data = data.Replace("{", string.Empty);
            data = data.Replace("}", string.Empty);
        }*/

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
