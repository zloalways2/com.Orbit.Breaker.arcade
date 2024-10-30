using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class TapItem : MonoBehaviour, IPointerClickHandler
    {
        public Image Image;

        public bool IsRightItem;

        public Action<TapItem> OnTap;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnTap?.Invoke(this);
        }

       
    }
}