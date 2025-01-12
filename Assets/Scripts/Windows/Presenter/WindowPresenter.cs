using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;
using static Newspaper.Windows.WindowView;
using System;

namespace Newspaper.Windows
{
    public class WindowPresenter : MonoBehaviour
    {
        [SerializeField] private WindowView _view;
        private WindowModel _model;

        private void Start()
        {
            _model = new WindowModel();

            _model.CurrentWindow.Subscribe(windowType =>
            {
                _view.ShowWindow(windowType);
            }).AddTo(this);

            _view.Weatherbutton.OnClickAsObservable().Subscribe(_ => OpenWindow(WindowType.WeatherWindow)).AddTo(this);
            _view.FactsButton.OnClickAsObservable().Subscribe(_ => OpenWindow(WindowType.FactsWindow)).AddTo(this);
            UIActions.Facts_LoadFactAction += ShowFactPopUp;
        }

        private void ShowFactPopUp(string name, string desc)
        {
            _view.StateFactPopUp(true);
            var popup= _view.GetPopUp();
            popup.TitleText.text= name;
            popup.InfoText.text= desc;
        }
     

        private void OpenWindow(WindowType windowType)
        {
            _model.CurrentWindow.Value = windowType;
            LoadWindowDataAsync(windowType).Forget();
        }

        private async UniTaskVoid LoadWindowDataAsync(WindowType windowType)
        {
           
            await UniTask.Delay(1000); 

            switch (windowType)
            {
                case WindowType.WeatherWindow:
                    UIActions.Weather_ClearQueueAction.Invoke();
                 
                    break;
                case WindowType.FactsWindow:
                    UIActions.Facts_LoadListAction.Invoke();
                    break;
                default:
                    break;
            }
        }
    }
}