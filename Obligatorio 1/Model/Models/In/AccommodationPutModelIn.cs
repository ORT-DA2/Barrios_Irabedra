using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.In
{
    public class AccommodationPutModelIn
    {
        public List<string> Images  { get; set; }
        public bool ChangeCapacity { get; set; }
        public bool FullCapacity { get; set; }

        public AccommodationPutModelIn()
        {
            Images = new List<string>();
            ChangeCapacity = false;
            FullCapacity = false;
        }
    }
}
