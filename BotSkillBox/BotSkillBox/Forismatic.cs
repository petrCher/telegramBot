using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotSkillBox
{
    public class Forismatic
    {
        public class Quote
        {
            public string quoteText { get; set; }
            public string quoteAuthor { get; set; }
        }
        private RestClient RC = new RestClient();
        private const string URL = "https://api.forismatic.com/api/1.0/?method=getQuote&format=json&lang=ru";
        public Forismatic()
        {
            
        }
        public string GetRandom()
        {
            var Request = new RestRequest(URL);
            var Responce = RC.Get(Request);
            var json = Responce.Content;
            var quote = JsonConvert.DeserializeObject<Quote>(json);
            if (quote.quoteAuthor.Length > 0)
            {
                return $"Мудрый {quote.quoteAuthor} однажды сказал: {quote.quoteText}";
            }
            else
            {
                return quote.quoteText;
            }
        }
    }
}
