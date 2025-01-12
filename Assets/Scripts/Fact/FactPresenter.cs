using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Newspaper.Fact
{
    public class FactPresenter : MonoBehaviour
    {
        [SerializeField] private FactView _view;

        private void Start()
        {
            _view.Loading.SetActive(true);
            UIActions.Facts_LoadListAction += () =>
            {
                LoadList().Forget();
            };
        }
        private List<data> loadedDataList = new List<data>();
        private async UniTask LoadList()
        {
            FactRequest factRequest = new FactRequest();

            string result = await factRequest.Execute();
            _view.Loading.SetActive(false);
            Debug.Log(result);
            FactData factData = JsonUtility.FromJson<FactData>(result);
            int countData = factData.data.Length;


            Debug.Log(countData);
            for (int i = 0; i < 10; i++)
            {
                int buttonIndex = i;
                Debug.Log(i + " " + countData);
                if (countData > i)
                {
                    _view.FactLines[i].IDText.text = (i + 1).ToString();
                    _view.FactLines[i].Text.text = factData.data[i].attributes.name;
                    _view.FactLines[i].Button.OnClickAsObservable().Subscribe(_ => LoadFact(factData.data[buttonIndex].id).Forget()).AddTo(this);
                    Debug.Log(_view.FactLines[i].Text.text);
                }
            }

        }


        private async UniTask LoadFact(string id)
        {
            Debug.Log(id);
            FactRequest factRequest = new FactRequest();
            string result = await factRequest.LoadFactAsync(id);
            Debug.Log(result);
            OneFactData factData = JsonUtility.FromJson<OneFactData>(result);
            string name = factData.data.attributes.name;
            string description = factData.data.attributes.description;
            UIActions.Facts_LoadFactAction.Invoke(name, description);
        }

        [Serializable]
        public class OneFactData
        {
            public data data;
        }

        [Serializable]
        public class FactData
        {
            public data[] data;
        }

        [Serializable]
        public class data
        {
            public string id;
            public attributes attributes;
        }

        [Serializable]
        public class attributes
        {
            public string name;
            public string description;
        }
    }
}