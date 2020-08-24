using LeavetownHomework.API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace LeavetownHomework.API.Services
{
    /// <summary>
    /// Manages the calls to Fixer, a 3rd party API service
    /// Could be better with a generic name like CurrencyService to isolate from 3rd party API
    /// </summary>
    public class FixerAPIService
    {
        public static async Task<FixerConvertResponse> Convert(DateTime date, string fromCurrency, string toCurrency, decimal amount)
        {
            //accessKey and baseURL should be stored in a configuration store (or appsettings.json)
            var accessKey = "999ecd1f3163954fded0905f4a964358";
            var baseURL = "http://data.fixer.io/api/convert";

            //Builds the API url with parameters
            var builder = new UriBuilder(baseURL);
            builder.Port = -1;

            var query = HttpUtility.ParseQueryString(builder.Query);
            query["access_key"] = accessKey;
            query["from"] = fromCurrency;
            query["to"] = toCurrency;
            query["amount"] = amount.ToString(CultureInfo.InvariantCulture);
            query["date"] = date.ToString("yyyy-MM-dd");

            builder.Query = query.ToString();
            string url = builder.ToString();

            //Calls the API 
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var result = await client.GetStringAsync(url);

            //Desierialize JSON response
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            //Should have some sort of  handling in case deserialization goes wrong
            return JsonSerializer.Deserialize<FixerConvertResponse>(result, options);
        }
    }
}
