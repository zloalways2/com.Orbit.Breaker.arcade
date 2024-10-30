using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class SettingsWindow : Window
    {
        [SerializeField]
        private Button _exitButton;
        
        [SerializeField]
        private AudioSource _buttonSource;
        [SerializeField]
        private AudioSource _musicSource;


        [SerializeField]
        private Slider _musicSwitcher;

        [SerializeField]
        private Slider _soundSwitcher;
        
        // [SerializeField]
        // private Image _soundFill;
        // [SerializeField]
        // private Image _musicFill;


        // [SerializeField]
        // private Button _plusSoundBtn;
        // [SerializeField]
        // private Button _minusSoundBtn;
        //
        //
        // [SerializeField]
        // private Button _plusMusicBtn;
        // [SerializeField]
        // private Button _minusMusicBtn;

        private float _volumeSound;
        private float _volumeMusic;
        
        
        [SerializeField] private Button _volumeButton;
        [SerializeField] private Button _musicButton;
        
        
        public override void Initialize()
        {
            base.Initialize();
            //
            // _plusMusicBtn.onClick.AddListener((() => { ChangeMusic(1);}));
            // _minusMusicBtn.onClick.AddListener((() => { ChangeMusic(-1);}));
            //
            // _plusSoundBtn.onClick.AddListener((() => { ChangeSound(1);}));
            // _minusSoundBtn.onClick.AddListener((() => { ChangeSound(-1);}));

            _exitButton.onClick.AddListener((() => { _manager.SwitchWindow(typeof(MenuWindow));}));
            
            _volumeMusic = 1f;
            _volumeSound = 1f;
            
            ProcessMusic(_volumeMusic);
            ProcessSound(_volumeSound);

            _musicButton.onClick.AddListener((() => ProcessMusic(_volumeMusic>0f ? 0f: 1f)));
            _volumeButton.onClick.AddListener((() => ProcessSound(_volumeSound>0f ? 0f: 1f)));
            
            // _musicSwitcher.onValueChanged.AddListener(ProcessMusic);
            // _soundSwitcher.onValueChanged.AddListener(ProcessSound);

            // _musicSwitcher.onChangeState += (b => { _musicSource.gameObject.SetActive(b); });
            // _soundSwitcher.onChangeState += (b => { _buttonSource.gameObject.SetActive(b); });
            //
        }

        private void ProcessMusic(Single normalized)
        {
            // _musicFill.fillAmount = _volumeMusic;
            _musicSource.volume = normalized;
            _volumeMusic = normalized;
        }
        
        private void ProcessSound(Single normalized)
        {
            // _soundFill.fillAmount = _volumeSound;
            _buttonSource.volume = normalized;
            _volumeSound = normalized; 
        }

        private void ChangeMusic(int i)
        {
            _volumeMusic += (0.1666f * i);

            if (_volumeMusic >= 1f)
                _volumeMusic = 1f;

            if (_volumeMusic <= 0f)
                _volumeMusic = 0f;
            
            //ProcessMusic();
        }

        private void ChangeSound(int i)
        {
            _volumeSound += (0.1666f * i);

            if (_volumeSound >= 1f)
                _volumeSound = 1f;

            if (_volumeSound <= 0f)
                _volumeSound = 0f;
            
            //ProcessSound();
        }


        public void PlayButtonSound()
        {
            _buttonSource.Play();
        }
    }
}