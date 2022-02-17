using System.Net;
using Nancy.Json;
using Shop.Core.ServiceInterface;
using Shop.Core.Dtos.Weather;
using Shop.Core.Dto.Weather;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apikey = "wvXzY2ev4SxvtuulTE67P9W9eqQ5AkFf";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=wvXzY2ev4SxvtuulTE67P9W9eqQ5AkFf";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
<<<<<<< HEAD
                //ainult ühe classi saab deserialiseerida
                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;

                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                dto.DailyForecastsDate = weatherInfo.DailyForecasts[0].Date;
                dto.DailyForecastsEpochDate = weatherInfo.DailyForecasts[0].EpochDate;

                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;

                var jsonString = new JavaScriptSerializer().Serialize(dto);

                //return jsonString;
=======
                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);
                HeadlineDto headlineInfo = (new JavaScriptSerializer()).Deserialize<HeadlineDto>(json);

                WeatherResultDto result = new WeatherResultDto();

                result.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                result.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                result.Severity = weatherInfo.Headline.Severity;
                result.Text = weatherInfo.Headline.Text;
                result.Category = weatherInfo.Headline.Category;
                result.EndDate = weatherInfo.Headline.EndDate;
                result.EndEpochDate = weatherInfo.Headline.EndEpochDate;
                result.MobileLink = weatherInfo.Headline.MobileLink;
                result.Link = weatherInfo.Headline.Link;
                result.DailyForecastsDate = weatherInfo.DailyForecasts.Date;
                result.DailyForecastsEpochDate = weatherInfo.DailyForecasts.EpochDate;
                result.TempMinValue = weatherInfo.DailyForecasts.Temperature.Minimum.Value;
                result.TempMinUnit = weatherInfo.DailyForecasts.Temperature.Minimum.Unit;
                result.TempMinUnitType = weatherInfo.DailyForecasts.Temperature.Minimum.UnitType;

                var jsonString = new JavaScriptSerializer().Serialize(result);

                return jsonString;
>>>>>>> e9ca39bb0a5edc9288b8ec0a68689bd10a73f839
            }
            return dto;
        }
    }
}