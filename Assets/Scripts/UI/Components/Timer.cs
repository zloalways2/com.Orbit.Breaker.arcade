using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Image _fill;

        [SerializeField]
        private bool isWithBar;

        [SerializeField]
        private bool decreasingBar;

        [SerializeField]
        private string _textFormat;

        [SerializeField]
        private int _goalTime;

        private DateTime _endTime;

        private DateTime _startTime;


        private Action _onComplete;

        public void StartTime(Action callback, int roundTime = 60)
        {
            _onComplete = callback;

            _startTime = DateTime.Now;
            _goalTime = roundTime;
            _endTime = _startTime.AddSeconds(_goalTime);
           

            StartCoroutine(TimerProcess());
        }

        private IEnumerator TimerProcess()
        {
            while ((DateTime.Now - _startTime).TotalSeconds < _goalTime)
            {
                RenderText();
                
                if(isWithBar)
                    RenderBar();
                
                yield return null;
            }
            
            _onComplete?.Invoke();
        }


        private void RenderText()
        {
            var remainingTime = _endTime - DateTime.Now;
            _text.text = remainingTime.ToString(_textFormat);
        }

        private void RenderBar()
        {
            var secondsLeft = _endTime -  DateTime.Now;
            if(decreasingBar)
                _fill.fillAmount = 1f - (float)secondsLeft.TotalSeconds/_goalTime;
            else
                _fill.fillAmount = (float)secondsLeft.TotalSeconds/_goalTime;
        }
        public void StopTimer()
        {
            _onComplete = null;
            
            StopCoroutine(TimerProcess());
        }

        public TimeSpan GetSecondsLeft()
        {
            return _endTime - DateTime.Now;
        }

        public void MinusTimer(int i)
        {
            _endTime -= TimeSpan.FromSeconds(i);
            _goalTime -= i;
        }

        public void PlusTimer(int i)
        {
            _endTime += TimeSpan.FromSeconds(i);
            _goalTime += i;
        }
    }
}