using System.Collections.Generic;

namespace Obligatorio.Domain
{
    public class Region
    {
        public string Name { get; set; }
        public List<TouristSpot> TouristSpots { get; set; } 
        public int Id { get; set; }
        public Region()
        {
            Name = "Default Name";
            TouristSpots = new List<TouristSpot>();
        }

        public override bool Equals(object obj)
        {
            return obj is Region region &&
                   Name == region.Name;
        }

        public bool Validate()
        {
            switch (this.Name.ToLower())
            {
                case "region metropolitana":
                    return true;
                    break;
                case "region centro sur":
                    return true;
                    break;
                case "region este":
                    return true;
                    break;
                case "region litoral norte":
                    return true;
                    break;
                case "region corredor de los pajaros pintados":
                    return true;
                    break; 
            }
            return false;
        }
    }
}
