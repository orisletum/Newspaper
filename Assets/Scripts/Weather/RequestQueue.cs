using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Newspaper.Weather
{
    public class RequestQueue
    {
        private readonly Queue<Func<UniTask>> _requestQueue = new();
        private bool _isProcessing;
        private CancellationTokenSource cancelToken = new();

        public void Enqueue(Func<UniTask> request)
        {
            _requestQueue.Enqueue(request);
            ProcessQueue().Forget();
        }

        private async UniTaskVoid ProcessQueue()
        {
            if (_isProcessing) return;
            _isProcessing = true;

            while (_requestQueue.Count > 0 && !cancelToken.Token.IsCancellationRequested)
            {
                var request = _requestQueue.Dequeue();
                try
                {
                    await request();
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex.Message);
                }
            }

            _isProcessing = false;
        }

        public void ClearQueue()
        {
            cancelToken.Cancel();
            cancelToken = new CancellationTokenSource();
            _requestQueue.Clear();
        }
    }
}