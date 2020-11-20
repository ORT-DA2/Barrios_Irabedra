using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.Model.Models.In
{
    public class ReportModelIn
    {
        public string TouristSpotName { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public ReportModelIn()
        {
        }
    }
}
