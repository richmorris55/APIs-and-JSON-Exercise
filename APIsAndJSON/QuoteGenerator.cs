using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
	public class QuoteGenerator
	{
		public static async Task KanyeQuote()
		{
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest/";

            var kanyeResponse = await client.GetStringAsync(kanyeURL)?? throw new Exception("Failed to get Kanye Response.");

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote")?.ToString();

            Console.WriteLine($"---------------");

            Console.WriteLine($"Kanye:  '{kanyeQuote}'");

            Console.WriteLine($"-------------");
            
        }


        public static async Task RonQuote()
        {
            var client = new HttpClient();

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = await client.GetStringAsync(ronURL) ?? throw new Exception("Failed to get Ron Response.");

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            Console.WriteLine($"---------------");

            Console.WriteLine($"Ron:  '{ronQuote}'");

            Console.WriteLine($"-------------");

        }




        public static async Task Conversation()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("---------------------------------------");

               await QuoteGenerator.KanyeQuote();

               await QuoteGenerator.RonQuote();

               Console.WriteLine();

            }

        }
	}
}

