using Newspaper.Fact;
using UnityEngine;
using UnityEngine.UI;

namespace Newspaper.Windows
{
    public class WindowView : MonoBehaviour
    {
        public enum WindowType
        {
            WeatherWindow,
            FactsWindow,
            LoadingWindow
        }

        [SerializeField] private Button weatherButton;
        public Button Weatherbutton => weatherButton;

        [SerializeField] private Button factsButton;
        public Button FactsButton => factsButton;

        [SerializeField] private GameObject _window1;
        [SerializeField] private GameObject _window2;
        [SerializeField] private GameObject FactPopUp;

        public void StateFactPopUp(bool state)
        {
            FactPopUp.SetActive(state);
        }

        public FactInfo GetPopUp() => FactPopUp.GetComponent<FactInfo>();

        public void ShowWindow(WindowType windowName)
        {
            _window1.SetActive(windowName.Equals(WindowType.WeatherWindow));
            _window2.SetActive(windowName.Equals(WindowType.FactsWindow));
            FactPopUp.SetActive(windowName.Equals(WindowType.LoadingWindow));
        }
    }
}