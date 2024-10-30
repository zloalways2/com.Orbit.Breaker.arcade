using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelectionWindow : Window
    {
        [SerializeField]
        private LevelSelectButton _btnPrefab;

        [SerializeField]
        private bool withStarsMechanic;
        
        [SerializeField]
        private int levelCount;

        [SerializeField]
        private GridLayoutGroup _gridLayoutGroup;

        [SerializeField]
        private LayoutGroupType _groupType;

        [SerializeField] private int constraintCount;
        
        private LevelSelectButton[] _levelSelectButtons;
        
        
        [SerializeField]
        private Button _exitToMenu;

        public override void Initialize()
        {
            base.Initialize();
            _exitToMenu.onClick.AddListener(()=>_manager.SwitchWindow(typeof(MenuWindow)));

            _levelSelectButtons = new LevelSelectButton[levelCount];

            for(int i =0; i < _levelSelectButtons.Length; i++)
            {
                var levelSelectButton =  Instantiate(_btnPrefab, _gridLayoutGroup.transform);;
                _levelSelectButtons[i] = levelSelectButton;
            }


            switch (_groupType)
            {
                case LayoutGroupType.Grid:
                    _gridLayoutGroup.constraint =GridLayoutGroup.Constraint.FixedColumnCount;
                    _gridLayoutGroup.constraintCount = constraintCount;
                    break;
                case LayoutGroupType.Horizontal:
                    _gridLayoutGroup.constraint =GridLayoutGroup.Constraint.FixedRowCount;
                    _gridLayoutGroup.constraintCount = 1;
                    break;
                case LayoutGroupType.Vertical:
                    _gridLayoutGroup.constraint =GridLayoutGroup.Constraint.FixedColumnCount;
                    _gridLayoutGroup.constraintCount = 1;
                    break;
            }

        }


        public override void Show()
        {
            base.Show();

            for (int i = 0; i < _levelSelectButtons.Length; i++)
            {
                if (withStarsMechanic)
                {
                    var stars = 0;
                    if (PlayerPrefs.HasKey($"LevelDone{i}"))
                    {
                        stars = PlayerPrefs.GetInt($"LevelDone{i}");
                    }
                    _levelSelectButtons[i].Configure(StartLevel,i, stars,true);
                }
                else
                {
                    _levelSelectButtons[i].Configure(StartLevel,i);
                }
            }
        }

        public void StartLevel(int levelIndex)
        {
            var game = _manager.SwitchWindow(typeof(RocketGameWindow)) as RocketGameWindow;

            // ReSharper disable once Unity.NoNullPropagation
            game?.StartGame(levelIndex);
        }


        [Serializable]
        public enum LayoutGroupType
        {
            Grid, Horizontal, Vertical
        }
    }
}