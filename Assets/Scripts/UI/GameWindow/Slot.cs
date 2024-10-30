using UnityEngine;

namespace UI
{
    public class Slot : MonoBehaviour
    {
        public int Id { get; private set; }

        [SerializeField]
        private RectTransform _rectTransform;

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetSize(float size)
        {
            _rectTransform.sizeDelta = new Vector2(size, size);
        }
    }
}