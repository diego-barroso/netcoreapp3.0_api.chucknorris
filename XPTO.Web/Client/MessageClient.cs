using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XPTO.Web.Models;

namespace XPTO.Web.Client
{
    public class MessageClient
    {


        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public MessageClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public MessageModel GetMessage(string category)
        {
            category = !string.IsNullOrEmpty(category) ? $"?category={category}" : string.Empty;
            var url = $"jokes/random{category}";
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<MessageModel>(response.Content.ReadAsStringAsync().Result);
        }
    }
}