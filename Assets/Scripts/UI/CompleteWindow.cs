using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CompleteWindow : Window
    {
        [Header("Common")] 
        [SerializeField]
        private TextMeshProUGUI _tittle;
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        [SerializeField]
        private Button _exitButton;

        [SerializeField] private TMP_Text _levelNumberText;
        
        [Header("Win UI")]
        [SerializeField]
        private Button _winButton;

        
        [Header("Lose UI")]
        [SerializeField]
        private Button _tryAgainButton;
        
        [SerializeField] private TMP_Text[] _goals;
        [SerializeField] private Image[] _goalImages;
        [SerializeField] private Sprite[] _images;

        public override void Initialize()
        {
            base.Initialize();
            
            _tryAgainButton.onClick.AddListener(OnTryAgainPressed);
            _winButton.onClick.AddListener(OnTryAgainPressed);
            _exitButton.onClick.AddListener(OnExitPressed);
        }
        
        private void RenderTargets(int[] results, int targetAmount)
        {
            for(int i =0; i < _goals.Length; i++)
            {
                _goals[i].text = $"{results[i]}/{targetAmount}";
            }
        }

        private void OnExitPressed()
        {
            _manager.SwitchWindow(typeof(MenuWindow));
        }

        private void OnTryAgainPressed()
        {
            _manager.SwitchWindow(typeof(LevelSelectionWindow));
        }

        public void SetWindow(int[] results, int[] ids, int targetAmount, bool isWin, int score, int level)
        {
            _levelNumberText.text = $"Level {level}";
            RenderTargets(results, targetAmount);

            var bestScore = PlayerPrefs.GetInt("SCORE", 0);
            PlayerPrefs.SetInt("SCORE",score+bestScore);
            _goalImages[0].sprite = _images[ids[0]];
            _goalImages[1].sprite = _images[ids[1]];
            _goalImages[2].sprite = _images[ids[2]];
            
            if (isWin)
            {
                _scoreText.text = $"SCORE \n {score}";
                _tittle.text = "VICTORY";
                
                _winButton.gameObject.SetActive(true);
                _tryAgainButton.gameObject.SetActive(false);
            }
            else
            {
                _scoreText.text = "LEVEL IS NOT COMPLETE";
                _tittle.text = "LOSE";
                
                _winButton.gameObject.SetActive(false);
                _tryAgainButton.gameObject.SetActive(true);
            }
        }
    }
}