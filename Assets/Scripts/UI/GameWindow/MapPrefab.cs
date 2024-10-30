using UnityEngine;

namespace UI
{
    public class MapPrefab : MonoBehaviour
    {
        [SerializeField]
        private Transform startPoint;
        [SerializeField]
        private Transform exitPoint;

        public Vector2 ExitPosition => exitPoint.position;
        public Vector3 StartPosition => startPoint.position;
    }
}