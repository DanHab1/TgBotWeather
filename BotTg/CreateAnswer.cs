using BotTg.Db.CRUD;
using BotTg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotTg
{
    public class CreateAnswer : Bot
    {

        public static string CreateWeatherAnswer(WheatherM model)
        {
            int temp = Convert.ToInt32(model.main.temp) - 272;
            int feel = Convert.ToInt32(model.main.feels_like) - 272;
            string main = TranslateApi.TranslateText(model.weather[0].main);
            string descriptionMain = TranslateApi.TranslateText(model.weather[0].description);
            string city = TranslateApi.TranslateText(model.name);
            var rez = $"Погода в городе {city}:{Environment.NewLine}Температура: {temp}°C{Environment.NewLine}Ощущается как: {feel}°C{Environment.NewLine}На небе: {main} ({descriptionMain})";
            return rez;
        }

        public static async Task AutoWeatherAnswer(ITelegramBotClient botClient)
        {
            var weather = new WeatherApi();
            while (true)
            {
                var users = Query.GetUserAutoMessage();
                foreach (var user in users)
                {
                    var answ = weather.GetWeather(user.City);
                    await botClient.SendTextMessageAsync(user.UserId, answ.Result);
                }
                Thread.Sleep(180000);
            }
        }
    }
}
