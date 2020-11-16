using System.Collections.Generic;

namespace Obligatorio.Model.Models.In
{
    public class AccommodationPutModelIn
    {
        public List<string> Images  { get; set; }
        public string Name { get; set; }
        public string WantToChangeCapacity { get; set; }
        public string FullCapacity { get; set; }

        public AccommodationPutModelIn()
        {
            Name = "";
            Images = new List<string>();
            WantToChangeCapacity = "false";
            FullCapacity = "false";
        }
    }
}
