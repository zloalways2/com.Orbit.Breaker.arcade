using System;
using TMPro;
using UnityEngine;

namespace UI.Components
{
    public class ScoreHandler : MonoBehaviour
    {
        public int MaxScore;

        public Action OnWin;

        public TMP_Text ScoreText;
        
        public int Score { get; set; }
        
        public void PlusScore(int score)
        {
            Score += score;

            if (Score >= MaxScore)
            {
                Score = MaxScore;
                OnWin?.Invoke();
            }
            
            RenderScore();
        }
        
        public void RenderScore()
        {
            //ScoreText.text = $"{Score}/{MaxScore}";
            ScoreText.text = $"{Score}";
        }
    }
}