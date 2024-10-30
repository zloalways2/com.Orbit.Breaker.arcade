using UnityEngine;
using UnityEngine.Rendering;

namespace UI
{
    public class Window : MonoBehaviour
    {
        protected WindowsManager _manager;
        
        protected bool _isFirstShow = true;
        public virtual void Initialize()
        {
            
        }
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Configure(WindowsManager windowsManager)
        {
            _manager = windowsManager;
        }
    }
}