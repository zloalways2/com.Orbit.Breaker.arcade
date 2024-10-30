using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class RocketGameWindow : Window
    {
        [Header("Top UI")] 
        [SerializeField]
        private Button _exitButton;
        [SerializeField]
        private Button _settingsButton;
        
        [SerializeField]
        private Timer _timer;

        [SerializeField] private ScoreHandler _scoreHandler;

        [SerializeField]
        private Spawner spawner;

        [SerializeField] private TMP_Text[] _goals;
        [SerializeField] private Image[] _goalImages;
        [SerializeField] private Sprite[] _images;

        private int _currentLevelIndex;
        
        
        private List<(int, int)> _targetIds;

        private int _targetAmount => 15 + _currentLevelIndex;
        
        
        public void StartGame(int levelIndex)
        {
            _scoreHandler.PlusScore(0);
            _timer.StartTime(Lose ,120 + levelIndex*5);


            _targetIds = new List<(int, int)>();

            _targetIds.Add((Random.Range(0, 2),0));
            _targetIds.Add((Random.Range(2, 4),0));
            _targetIds.Add((Random.Range(4, 6),0));

            var ids= _targetIds.Select(tuple => tuple.Item1).ToArray();

            _goalImages[0].sprite = _images[ids[0]];
            _goalImages[1].sprite = _images[ids[1]];
            _goalImages[2].sprite = _images[ids[2]];
            spawner.StartLevel();
            RenderTargets();
        }
        
        public override void Initialize()
        {
            base.Initialize();

            _exitButton.onClick.AddListener(ExitButtonPressed);
            _settingsButton.onClick.AddListener(SettingButtonPressed);
            
        }
        
        private void ExitButtonPressed()
        {
            _timer.StopTimer();
            _manager.SwitchWindow(typeof(MenuWindow));
            spawner.gameObject.SetActive(false);
        }

        private void SettingButtonPressed()
        {
            _timer.StopTimer();
            _manager.SwitchWindow(typeof(SettingsWindow));
            spawner.gameObject.SetActive(false);
            
        }

        public void TapObjectTouched(int id)
        {
            if (_targetIds.Any(x=> x.Item1 == id))
            {
                _scoreHandler.PlusScore(10);
                _timer.PlusTimer(5);
                var index = _targetIds.FindIndex(x=> x.Item1 == id);
                
                
                var item2 = _targetIds[index].Item2;
                if (item2 < _targetAmount)
                {
                    item2++;
                    _targetIds[index] = (id,item2);
                }
                    

                if (_targetIds.Any(x => x.Item2 < _targetAmount))
                {
                    RenderTargets();
                }
                else
                {
                    Win();
                }
                
            }
            else
            {
                _timer.MinusTimer(5);
            }
            
            // if(_rocket.Health == 0)
            //     Lose();
        }

        private void RenderTargets()
        {
            for(int i =0; i < _goals.Length; i++)
            {
                _goals[i].text = $"{_targetIds[i].Item2}/{_targetAmount}";
            }
        }

        private void Lose()
        {
            _timer.StopTimer();
            spawner.gameObject.SetActive(false);
            var completeWindow =_manager.SwitchWindow(typeof(CompleteWindow)) as CompleteWindow;
            
            var results= _targetIds.Select(tuple => tuple.Item2).ToArray();
            var ids = _targetIds.Select(typle => typle.Item1).ToArray();
            completeWindow?.SetWindow(results,ids,_targetAmount,false, _scoreHandler.Score,_currentLevelIndex + 1 );
        }
        


        private void Win()
        {
            _timer.StopTimer();
            spawner.gameObject.SetActive(false);
            var completeWindow =_manager.SwitchWindow(typeof(CompleteWindow)) as CompleteWindow;
            
            var results= _targetIds.Select(tuple => tuple.Item2).ToArray();
            var ids = _targetIds.Select(typle => typle.Item1).ToArray();
            completeWindow?.SetWindow(results,ids,_targetAmount,true, _scoreHandler.Score, _currentLevelIndex+1);
            
            PlayerPrefs.SetInt($"LevelDone{_currentLevelIndex}",1);
        }
    }
}