using System;
using UnityEngine;

namespace Platformer2d
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Item _prefab;
        [SerializeField] private Transform[] _spawnPoints;

        public event Action<int> ItemsSpawned;

        private void Start()
        {
            SpawnItems();
        }

        private void SpawnItems()
        {
            int spawned = 0;

            foreach (Transform spawnPoint in _spawnPoints)
            {
                Item item = Instantiate(_prefab, spawnPoint.transform.position,
                    Quaternion.identity, transform);
                item.Collected += OnItemCollected;
                spawned++;
            }

            ItemsSpawned?.Invoke(spawned);
        }

        private void OnItemCollected(Item item)
        {
            item.Collected -= OnItemCollected;
            Destroy(item.gameObject);
        }

#if UNITY_EDITOR
        [ContextMenu("Refresh Child Array")]
        private void RefreshChildArray()
        {
            int pointCount = transform.childCount;
            _spawnPoints = new Transform[pointCount];

            for (int i = 0; i < pointCount; i++)
                _spawnPoints[i] = transform.GetChild(i);
        }
#endif
    }
}