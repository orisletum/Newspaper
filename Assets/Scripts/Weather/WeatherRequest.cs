using Cysharp.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Networking;

namespace Newspaper.Weather
{
    public class WeatherRequest
    {
        public string URLWeather = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
        public string URLFacts = "https://dogapi.dog/api/v2";
        public string GETListBreeds = "/breeds";
        private static readonly HttpClient _httpClient = new HttpClient();

        public async UniTask<string> Execute()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Egor", "123123123");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Unity Web Request");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await _httpClient.GetAsync(URLWeather);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async UniTask<Sprite> LoadImageAsync(string url)
        {
            using (var request = UnityWebRequestTexture.GetTexture(url))
            {
                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    return null;
                }

                var texture = DownloadHandlerTexture.GetContent(request);

                return Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f)
                ); ;
            }
        }
    }
}