using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.OpenWeather;
using Shop.OpenWeatherMapModels;
using Shop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Controllers
{
    public class OpenWeatherAppController : Controller
    {
        private readonly IOpenWeatherRepository _openweatherRepository;

       
        public OpenWeatherAppController(IOpenWeatherRepository openweatherAppRepo)
        {
            _openweatherRepository = openweatherAppRepo;
        }

       
        public IActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
           
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Shop", new { city = model.CityName });
            }
            return View(model);
        }

      
        public IActionResult City(string city)
        {
            
            WeatherResponse weatherResponse = _openweatherRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Temp = weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
            return View(viewModel);
        }
    }
}