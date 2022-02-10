namespace Shop.Controllers
{
    public class WeatherForecastController
    {
        [HttpGet]

        public IActionResult Index ()
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

        [HttpGet]

        public IActionResult City(string city)
        {
            var weatherResponse = 1;
            City vm = new City();

            return View(vm);

        }


    }
}
