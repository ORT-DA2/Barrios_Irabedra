using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.Out
{
    public class ReportLineModelOut
    {
        public string AccommodationName { get; set; }
        public int Reservations { get; set; }
        public int Id { get; set; }

        public ReportLineModelOut()
        {

        }
        public ReportLineModelOut(string accommodationName, int id)
        {
            this.AccommodationName = accommodationName;
            this.Id = id;
            this.Reservations = 0;
        }
    }
}
