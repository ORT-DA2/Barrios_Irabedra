using System.Collections.Generic;

namespace Obligatorio.Model.Models.In
{
    public class AccommodationPutModelIn
    {
        public List<string> Images  { get; set; }
        public bool WantToChangeCapacity { get; set; }
        public bool FullCapacity { get; set; }

        public AccommodationPutModelIn()
        {
            Images = new List<string>();
            WantToChangeCapacity = false;
            FullCapacity = false;
        }
    }
}
