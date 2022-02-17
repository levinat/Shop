using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Dto.Weather
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public DailyForecastsDto DailyForecasts { get; set; }
    }
}
