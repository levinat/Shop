using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Nancy.Json;
using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;
using Shop.Core.Dtos.Weather;
using Shop.Core.Dto.Weather;



namespace Shop.Core.Dtos.Weather
{
    public class WeatherResultDto
    {

        public string EffectiveDate { get; set; }
        public Int64 EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string EndDate { get; set; }
        public Int64 EndEpochDate { get; set; }


        public string DailyForecastsDate { get; set; }
        public int DailyForecastsEpochDate { get; set; }


        public double TempMinValue { get; set; }
        public string TempMinUnit { get; set; }
        public int TempMaxUnitType { get; set; }
        public int DayIcon { get; set; }
        public string DayIconPhrase { get; set; }
        public bool DayHasPrecipitation { get; set; }

        public string DayPrecipitationType { get; set;}
        public string DayPrecipitationIntensity { get; set; }

        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; }
        public bool NightHasPrecipitation { get; set; }

        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}


