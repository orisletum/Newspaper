using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Newspaper.Weather
{
    public class WeatherView : MonoBehaviour
    {
        [SerializeField] private TMP_Text weatherValueText;
        [SerializeField] private Image weatherIcon;
        public TMP_Text WeatherValueText => weatherValueText;
        public Image WeatherIcon => weatherIcon;

    }
}