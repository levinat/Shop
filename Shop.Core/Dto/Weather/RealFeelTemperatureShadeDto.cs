﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dto.Weather
{
    public class RealFeelTemperatureShadeDto
    {
        public MinimumDto Minimum { get; set; }
        public MaximumDto Maximum { get; set; }
    }
}