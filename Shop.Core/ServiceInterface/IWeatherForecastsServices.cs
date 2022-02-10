using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ServiceInterface
{
    public interface IWeatherForecastServices : IApplicationService
    {
        string WeatherDetail(string city);
    }
}
