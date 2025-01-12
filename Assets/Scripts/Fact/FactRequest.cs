using Cysharp.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;

namespace Newspaper.Fact
{
    public class FactRequest
    {
        public string URLFacts = "https://dogapi.dog/api/v2";
        public string GETListBreeds = "/breeds/";
        private static readonly HttpClient _httpClient = new HttpClient();

        public async UniTask<string> Execute()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Egor", "123123123");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Unity Web Request");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await _httpClient.GetAsync(URLFacts + GETListBreeds);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async UniTask<string> LoadFactAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Egor", "123123123");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Unity Web Request");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            using (var request = new HttpRequestMessage(HttpMethod.Get, URLFacts + GETListBreeds + id.ToString()))
            {
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}