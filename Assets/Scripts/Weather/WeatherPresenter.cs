using Cysharp.Threading.Tasks;
using Newspaper.Windows;
using System;
using System.Linq;
using UnityEngine;
namespace Newspaper.Weather
{
    public class WeatherPresenter : MonoBehaviour
    {
        private WeatherRequest _weatherRequest;
        [SerializeField] private WeatherRequestQueue _queue;
        [SerializeField] private WeatherView _view;

        private void Start()
        {
            UIActions.Weather_UpdateAction += (x) =>
            {
                UpdateWeather(x).Forget();
            };
        }

        private async UniTask UpdateWeather(string data)
        {
            WeatherData weatherData = JsonUtility.FromJson<WeatherData>(data);
            _view.WeatherValueText.text = weatherData.properties.periods[0].name + " "
                + weatherData.properties.periods[0].temperature + " "
                + weatherData.properties.periods[0].temperatureUnit;
            var imageUrl = weatherData.properties.periods[0].icon;

            WeatherRequest _weatherRequest = new WeatherRequest();
            _view.WeatherIcon.sprite = await _weatherRequest.LoadImageAsync(imageUrl);
        }

        [Serializable]
        public class WeatherData
        {
            public properties properties;
        }

        [Serializable]
        public class properties
        {
            public periods[] periods;
        }

        [Serializable]
        public class periods
        {
            public string name;
            public int temperature;
            public string temperatureUnit;
            public string icon;
        }
    }
}