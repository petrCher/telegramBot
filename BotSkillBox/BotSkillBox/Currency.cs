using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotSkillBox
{
    public class Currency
    {
        public class ApiResult
        {
            public Dictionary<string, Rate> Valute { get; set; }
        }
        public class Rate
        {
            public int Nominal { get; set; }
            public string Name { get; set; }
            public float Value { get; set; }
        }
        private RestClient RC = new RestClient();
        private const string API_URL = "https://www.cbr-xml-daily.ru/daily_json.js";
        private ApiResult rates;
        public Currency()
        {

        }
        //string currency
        public void Download()
        {
            var Request = new RestRequest(API_URL);
            var Responce = RC.Get(Request);
            var json = Responce.Content;
            rates = JsonConvert.DeserializeObject<ApiResult>(json);
        }
        public string GetRate(string currency)
        {
            if (rates.Valute.ContainsKey(currency))
            {
                var rate = rates.Valute[currency];
                return $"За {rate.Nominal} {rate.Name} дают {rate.Value} рублей.";
            }
            else
            {
                return $"Здесь нет валюты {currency}.";
            }
        }
    }
}
