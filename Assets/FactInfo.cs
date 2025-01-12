using TMPro;
using UnityEngine;

namespace Newspaper.Fact
{
    public class FactInfo : MonoBehaviour
    {
        [SerializeField] private TMP_Text infoText;
        public TMP_Text InfoText => infoText;

        [SerializeField] private TMP_Text titleText;
        public TMP_Text TitleText => titleText;
    }
}