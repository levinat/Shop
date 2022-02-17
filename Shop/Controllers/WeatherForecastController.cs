using Microsoft.AspNetCore.Mvc;
using Shop.Models.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class WeatherForecastController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            SearchCity model = new SearchCity();

            return View(model);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = vm.CityName });
            }

            return View(vm);
        }

        public IActionResult City(string city)
        {
            var weatherResponse = 1;
            CityViewModel vm = new CityViewModel();


            return View(vm);
        }
    }
}