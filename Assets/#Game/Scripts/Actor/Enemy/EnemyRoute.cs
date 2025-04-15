using UnityEngine;

namespace Platformer2d
{
    public class EnemyRoute : MonoBehaviour
    {
        [SerializeField] private Transform _route;
        [SerializeField] private Transform[] _waypoints;

        private int _currentWaypointIndex;

        public Transform CurrentWaypoint => _waypoints[_currentWaypointIndex];

        public void GoToNextPoint()
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }

#if UNITY_EDITOR
        [ContextMenu("Refresh Child Array")]
        private void RefreshChildArray()
        {
            int pointCount = _route.childCount;
            _waypoints = new Transform[pointCount];

            for (int i = 0; i < pointCount; i++)
                _waypoints[i] = _route.GetChild(i);
        }
#endif
    }
}