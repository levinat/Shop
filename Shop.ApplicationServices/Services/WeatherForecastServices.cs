using Nancy.Json;
using Shop.Core.Dto.Weather;
using Shop.Core.Dtos.Weather;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices

    {
        public string WeatherDetail(string city)
        {
            string apikey = "wvXzY2ev4SxvtuulTE67P9W9eqQ5AkFf";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=wvXzY2ev4SxvtuulTE67P9W9eqQ5AkFf";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                DailyForecastsDto weatherInfo = (new JavaScriptSerializer()).Deserialize<DailyForecastsDto>(json);
                HeadLineDto headlineInfo = (new JavaScriptSerializer()).Deserialize<HeadlineDto>(json);

                WeatherResultDto result = new WeatherResultDto();

                result.EffectiveDate = headlineInfo.EffectiveDate;
                result.EffectiveEpochDate = headlineInfo.EffectiveEpochDate;
                result.Severity = headlineInfo.Severity;
                result.Text = headlineInfo.Text;
                result.Category = headlineInfo.Category;
                result.EndDate = headlineInfo.EndDate;
                result.EndEpochDate = headlineInfo.EndEpochDate;
                result.MobileLink = headlineInfo.MobileLink;
                result.Link = headlineInfo.Link;
                result.DailyForecastsDate = headlineInfo.DailyForecastsDate;
                result.DailyForecastsEpochDate = headlineInfo.DailyForecastsEpochDate;
                result.TempMinValue = weatherInfo.Temperature.Minimum.Value;
                result.TempMinUnit = weatherInfo.Temperature.Minimum.Unit;
                result.TempMinUnitType = weatherInfo.Temperature.Minimum.Unit.Type;

                var jsonString = new JavaScriptSerializer().Serializer(result);

                return jsonString;

            }
        }

    }
}

