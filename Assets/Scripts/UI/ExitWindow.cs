using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExitWindow : Window
    {
        [SerializeField]
        private Button _yesButton;

        [SerializeField]
        private Button _noButton;


        public override void Initialize()
        {
            base.Initialize();
            
            _yesButton.onClick.AddListener(Yes);
            _noButton.onClick.AddListener(No);
        }

        public void No()
        {
            _manager.SwitchWindow(typeof(MenuWindow));
        }

        private void Yes()
        {
            Application.Quit();
        }
    }
}