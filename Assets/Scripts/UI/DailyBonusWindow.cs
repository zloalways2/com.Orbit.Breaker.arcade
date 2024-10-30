using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DailyBonusWindow : Window
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private TMP_Text _buttonText;
        
        [SerializeField]
        private Button _button;

        private DateTime _nextUpdate;
        
        private bool _collected = false;

        public override void Initialize()
        {
            base.Initialize();
            _button.onClick.AddListener(Collect);
        }

        public override void Show()
        {
            var nextShow = PlayerPrefs.GetString("BONUS");
            
            if (DateTime.TryParse(nextShow, out var parsedDate))
            {
                _nextUpdate = parsedDate;
                _collected = true;
            }
            else
            {
                _nextUpdate = DateTime.Now;
            }

            if (_nextUpdate <= DateTime.Now)
            {
                _collected = false;
            }
            
            
            base.Show();
        }

        private void Update()
        {
            if (_collected)
            {
                var diff = _nextUpdate - DateTime.Now;
                _timerText.text =  $"{diff.Hours:D2}:{diff.Minutes:D2}:{diff.Seconds:D2}";
                _descriptionText.text = $"+250 POINTS";
                _buttonText.text = "MENU";
            }
            else
            {
                _timerText.text =  $"";
                _descriptionText.text = $"???";
                _buttonText.text = "OPEN";
            }
        }

        public void Collect()
        {
            if (!_collected)
            {
                var score = PlayerPrefs.GetInt("SCORE", 0);
                PlayerPrefs.SetInt("SCORE",score+250);
                _collected = true;

                _nextUpdate = DateTime.Now.AddHours(3);
                PlayerPrefs.SetString("BONUS",_nextUpdate.ToString("O"));
            }
            else
            {
                _manager.SwitchWindow(typeof(MenuWindow));
            }
        }
    }
}