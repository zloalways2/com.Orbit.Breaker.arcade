using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Image _fill;

        [SerializeField]
        private TextMeshProUGUI _text;
        

        public void SetProgress(float normalized, string text = "")
        {
            _fill.fillAmount = normalized;
            
            _text.text = text;
        }
    }
}