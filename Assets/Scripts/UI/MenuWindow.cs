using TMPro;
using UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuWindow : Window
    {
        [SerializeField]
        private bool withPreMenu;
        
        [Header("Pre Menu")]
        [SerializeField]
        private GameObject _preMenu;
        [SerializeField]
        private Button _policyInPreMenu;
        [SerializeField]
        private Button _okInPreMenu;
        
        [Header("Menu")]
        [SerializeField]
        private GameObject _menu;
        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _dailyButton;
        [SerializeField]
        private Button _policyButton;
        [SerializeField]
        private Button _exitButton;

        [SerializeField] 
        private TMP_Text _menuText;

        

        public override void Initialize()
        {
            base.Initialize();
            
            _policyInPreMenu.onClick.AddListener(ToPolicy);
            _okInPreMenu.onClick.AddListener(AcceptPrivacy);
            
            _playButton.onClick.AddListener(Play);
            _settingsButton.onClick.AddListener(ToSettings);
            _policyButton.onClick.AddListener(ToPolicy);
            _dailyButton.onClick.AddListener(ToDaily);
            _exitButton.onClick.AddListener(ToExit);
        }

        

        public override void Show()
        {
            base.Show();


            if (_isFirstShow && withPreMenu)
            {
                _isFirstShow = false;
                
                _menu.gameObject.SetActive(false);
                _preMenu.gameObject.SetActive(true);
            }
            else
            {
                _menu.gameObject.SetActive(true);
                _preMenu.gameObject.SetActive(false);

                _menuText.text = $"Score \n{PlayerPrefs.GetInt("SCORE", 0)}";
            }
        }
        
        private void ToExit()
        {
            _manager.SwitchWindow(typeof(ExitWindow));
        }

        private void ToDaily()
        {
            _manager.SwitchWindow(typeof(DailyBonusWindow));
        }
        
        private void ToSettings()
        {
            _manager.SwitchWindow(typeof(SettingsWindow));
        }

        private void Play()
        {
            _manager.SwitchWindow(typeof(LevelSelectionWindow));
        }
        
        private void ToPolicy()
        {
            _manager.SwitchWindow(typeof(PolicyWindow));
        }
        
        private void AcceptPrivacy()
        {
            _preMenu.gameObject.SetActive(false);
            _menu.gameObject.SetActive(true);
        }
    }
    
}