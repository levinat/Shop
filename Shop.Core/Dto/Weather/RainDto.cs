﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dto.Weather
{ 
    public class RainDto
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public Int32 UnitType { get; set; }
    }
}