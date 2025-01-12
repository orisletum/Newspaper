using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Newspaper.Weather
{
    public class WeatherRequestQueue : MonoBehaviour
    {
        private CancellationTokenSource _cancellationTokenSource;
        private RequestQueue _requestQueue;


        private void OnEnable()
        {
            UIActions.Weather_ClearQueueAction += ClearQueue;
            _requestQueue = new RequestQueue();
            _cancellationTokenSource = new CancellationTokenSource();
            AddWeatherRequests().Forget();
        }
        private void OnDisable()
        {
            UIActions.Weather_ClearQueueAction -= ClearQueue;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
        private void ClearQueue() => _requestQueue.ClearQueue();

        private async UniTask AddWeatherRequests()
        {
            try
            {
                while (true)
                {
                    _requestQueue.Enqueue(async () =>
                    {
                        WeatherRequest weatherRequest = new WeatherRequest();
                        string result = await weatherRequest.Execute();

                        UIActions.Weather_UpdateAction.Invoke(result);
                    });

                    await UniTask.Delay(5000, cancellationToken: _cancellationTokenSource.Token);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Stop Task");
            }
        }
    }
}