using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Config;
using Shop.OpenWeatherMapModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shop.Repositories;
using System.Net.Http;
using RestSharp;

namespace OpenWeather.Repositories
{

    public class OpenWeatherRepository : IOpenWeatherRepository
    {
        WeatherResponse IOpenWeatherRepository.GetForecast(string city)
        {
            string IDOWeather = Constants.OPEN_WEATHER_APPID;
            var client = new RestSharp.RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={IDOWeather}");
            var request = new RestSharp.RestRequest();
           client.execute(request);
            
            if (response.IsSuccessful)
            {
               
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

               
                return content.ToObject<WeatherResponse>();
            }

            return null;
        }
    }
}