﻿using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class SolarIrradianceDto
    {
        [JsonProperty("")]
        public double Value { get; set; }

        [JsonProperty("")]
        public string Unit { get; set; }

        [JsonProperty("")]
        public int UnitType { get; set; }
    }
}