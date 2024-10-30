using System.Collections;
using UI.Components;
using UnityEngine;

namespace UI
{
    public class LoadingWindow : Window
    {
        [SerializeField]
        private ProgressBar _progressBar;


        public override void Show()
        {
            base.Show();
            
            StartCoroutine(LoadingProcess());
        }

        private IEnumerator LoadingProcess()
        {
            var timer = 0f;

            while (timer < 2f)
            {
                timer += Time.deltaTime;
                _progressBar.SetProgress(timer/2f, "Loading");
                yield return null;
            }
            
            _manager.SwitchWindow(typeof(MenuWindow));
        }
    }
}