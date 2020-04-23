using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Models;

namespace WeatherApplication.Helpers
{
    public static class AccuWeatherHelper
    {
        private const string BASE_URI = "http://dataservice.accuweather.com/";
        private const string API_KEY = "HAwkyLPzg1CANHb5vJTYd2FRymc6WsAN";
        private const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        private const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>> GetCities(string context)
        {
            List<City> cities = new List<City>();

            string restURL = BASE_URI + String.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, context);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(restURL);
                var json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            string restURL = BASE_URI + String.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(restURL);
                var json = await response.Content.ReadAsStringAsync();
                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
