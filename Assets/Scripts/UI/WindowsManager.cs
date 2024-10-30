using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField]
        private Window[] _allWindows;

        private Window _currentWindow;

        
        public Type PreviousWindow { get; private set; }

        public void Initialize()
        {
            foreach (var window in _allWindows)
            {
                window.Configure(this);
                window.Initialize();
            }
        }
        
        public Window SwitchWindow(Type to, Type from = null)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Hide();
            }

            if (from != null)
            {
                PreviousWindow = from;
            }

            foreach (var window in _allWindows)
            {
                if (window.GetType() == to)
                {
                    window.Show();
                    _currentWindow = window;
                    return window;
                }
            }

            Debug.LogWarning("Can't find window :"+ to.FullName);
            return null;
        }
    }
}