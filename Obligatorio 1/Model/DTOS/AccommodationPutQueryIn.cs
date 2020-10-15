using Obligatorio.Model.Models.In;
using System.Collections.Generic;

namespace Obligatorio.Model.DTOS
{
    public class AccommodationPutQueryIn
    {
        public List<string> Images { get; set; }
        public bool ChangeCapacity { get; set; }
        public bool FullCapacity { get; set; }
        public int AccommodationId { get; set; }

        public AccommodationPutQueryIn(AccommodationPutModelIn accommodationPutModelIn, int id)
        {
            Images = accommodationPutModelIn.Images;
            ChangeCapacity = accommodationPutModelIn.WantToChangeCapacity;
            FullCapacity = accommodationPutModelIn.FullCapacity;
            AccommodationId = id;
        }
    }
}
