using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.Out
{
    public class AccommodationModelOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int PricePerNight { get; set; }
        public bool FullCapacity { get; set; }



    }
}
