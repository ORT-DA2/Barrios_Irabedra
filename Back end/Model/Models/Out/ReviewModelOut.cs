using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.Out
{
    public class ReviewModelOut
    {
        public string Text { get; set; }
        public string AccommodationName { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ReviewModelOut() 
        { 
        }

    }
}
