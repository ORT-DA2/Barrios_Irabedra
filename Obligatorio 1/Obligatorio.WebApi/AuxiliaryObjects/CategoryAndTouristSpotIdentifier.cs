﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.WebApi.AuxiliaryObjects
{
    public class CategoryAndTouristSpotIdentifier
    {
        public int TouristSpotId { get; set; }
        public string CategoryName { get; set; }
        public CategoryAndTouristSpotIdentifier()
        {
        }
    }
}