using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dto.Weather
{ 
    public class DirectionDto
    {
        public double Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }
}