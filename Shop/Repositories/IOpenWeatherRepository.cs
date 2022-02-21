using Shop.OpenWeatherMapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public interface IOpenWeatherRepository
    {
        WeatherResponse GetForecast(string city);
    }
}