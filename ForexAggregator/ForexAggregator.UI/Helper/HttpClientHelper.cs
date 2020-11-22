using ForexAggregator.UI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ForexAggregator.UI.Helper
{
    public class HttpClientHelper
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<T> GetAsync<T>(string url, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
            using (var response = await httpClient.GetAsync(url))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }
        }

        public static async Task<T> PostAsync<T>(string url, string token, PostObject model)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(model.PostData), Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = await httpClient.PostAsync(url, httpRequestMessage.Content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }
        }
    }
}
