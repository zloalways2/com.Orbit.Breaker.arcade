using System;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private WindowsManager _windowsManager;

        private void Awake()
        {
            _windowsManager.Initialize();
            
            _windowsManager.SwitchWindow(typeof(LoadingWindow));
        }
    }
}