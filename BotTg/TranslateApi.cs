using BotTg.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Requests.Abstractions;

namespace BotTg
{
    public class TranslateApi
    {
        private static string _host = "https://microsoft-translator-text.p.rapidapi.com/translate?to%5B0%5D=ru&api-version=3.0&profanityAction=NoAction&textType=plain";
        static RestClient client;
        public static string TranslateText(string text)
        {
            client = new RestClient();
            RestRequest req = new RestRequest(_host, Method.Post);
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("X-RapidAPI-Key", "bcb01cc36cmshc70b9fea2fd0fd5p1ce875jsn3185c9cf3cc6");
            req.AddHeader("X-RapidAPI-Host", "microsoft-translator-text.p.rapidapi.com");
            var transText = "[\r{\r\"Text\": \"$$$\"\r}\r]";
            req.AddParameter("application/json", transText.Replace("$$$", text), ParameterType.RequestBody);
            var resp = new RestResponse();
            resp = client.Execute(req);
            var r = resp.Content.Substring(1, resp.Content.Length-2);
            var model = JsonConvert.DeserializeObject<TranslateM>(r);
            return model.translations.FirstOrDefault().text;
        }
    }
}
