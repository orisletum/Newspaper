using System.Collections.Generic;
using UnityEngine;

namespace Newspaper.Fact
{
    public class FactView : MonoBehaviour
    {
        [SerializeField] private List<FactLine> factLines;
        public List<FactLine> FactLines => factLines;

        [SerializeField] private GameObject loading;
        public GameObject Loading => loading;
    }
}