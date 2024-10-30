using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelectButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private Image[] _stars;

        private Action<int> _callback;

        private int _level;

        private void Awake()
        {
            _button.onClick.AddListener(Pressed);
        }

        public void Configure(Action<int> pressCallback, int level, int stars = 0, bool withStars = false)
        {
            _callback = pressCallback;
            _level = level;

            _text.text = (level+1).ToString();


            if (!withStars)
                return;
            
            for (int i = 0; i < _stars.Length; i++)
            {
                if (i < stars)
                {
                    _stars[i].color = Color.white;
                }
                else
                {
                    _stars[i].color = Color.black;
                }
            }
        }

        public void Pressed()
        {
            _callback?.Invoke(_level);
        }
        
        
    }
}