using Obligatorio.Model.Models.In;
using System;
using System.Collections.Generic;
using System.Text;

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
            ChangeCapacity = accommodationPutModelIn.ChangeCapacity;
            FullCapacity = accommodationPutModelIn.FullCapacity;
            AccommodationId = id;
        }
    }
}
