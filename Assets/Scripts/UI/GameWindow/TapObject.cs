using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class TapObject : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Sprite[] _sprites;

        [SerializeField] private Image _image;
        
        public float Speed;
        
        public Action<int> OnClick;

        public int Id;
        
        private void Update()
        {
            transform.position -= new Vector3(0, Speed * Time.deltaTime, 0f);
        }
        
        public void Complete()
        {
            CancelInvoke(nameof(Complete));
            
            Destroy(gameObject);
        }
        
        

        public void OnPointerDown(PointerEventData eventData)
        {
            Complete();
            OnClick?.Invoke(Id);
        }

        public void SetId(int index)
        {
            Invoke(nameof(Complete), 10f);

            Id = index;
            _image.sprite = _sprites[Id];
        }
    }
}