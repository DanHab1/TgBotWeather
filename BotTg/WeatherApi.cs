using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotTg.Model;
using BotTg;

namespace BotTg
{
    public class WeatherApi
    {
        private string _token = "85c8e05f14e1926e2c73eabc5ab6d182";
        private string _host = "https://api.openweathermap.org/data/2.5/weather";
        RestClient client;

        public async Task<string> GetWeather(string nameCity)
        {
            client = new RestClient();
            RestRequest request = new RestRequest(_host, Method.Get);
            request.AddQueryParameter("q", nameCity);
            request.AddQueryParameter("appid", _token);
            var response = client.Get(request);
            var model = JsonConvert.DeserializeObject<WheatherM>(response.Content);
            if (model.main != null)
            {
                return CreateAnswer.CreateWeatherAnswer(model);
            }
            else return "";
        }
    }
}
