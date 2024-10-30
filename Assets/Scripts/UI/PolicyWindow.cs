using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PolicyWindow : Window
    {
        [SerializeField]
        private Button _acceptButton;

        public override void Initialize()
        {
            base.Initialize();
            
            _acceptButton.onClick.AddListener(AcceptPolicy);
        }

        private void AcceptPolicy()
        {
            _manager.SwitchWindow(typeof(MenuWindow));
        }
    }
}