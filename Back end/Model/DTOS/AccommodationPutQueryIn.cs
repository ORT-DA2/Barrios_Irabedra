using Obligatorio.Model.Models.In;
using System.Collections.Generic;

namespace Obligatorio.Model.DTOS
{
    public class AccommodationPutQueryIn
    {
        public List<string> Images { get; set; }
        public bool ChangeCapacity { get; set; }
        public bool FullCapacity { get; set; }
        public string Name { get; set; }

        public AccommodationPutQueryIn(AccommodationPutModelIn accommodationPutModelIn)
        {
            Images = accommodationPutModelIn.Images;
            if(accommodationPutModelIn.WantToChangeCapacity == "true")
            {
                ChangeCapacity = true;
            }
            else
            {
                ChangeCapacity = false;
            }
            if (accommodationPutModelIn.FullCapacity == "true")
            {
                FullCapacity = true;
            }
            else
            {
                FullCapacity = false;
            }
            Name = accommodationPutModelIn.Name;
        }
    }
}
