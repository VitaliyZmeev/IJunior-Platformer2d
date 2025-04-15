using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(CoinCounter))]
    public class CoinCounterBootstrap : MonoBehaviour
    {
        [SerializeField] private ItemSpawner _coinSpawner;

        private CoinCounter _coinCounter;

        private void Awake()
        {
            _coinCounter = GetComponent<CoinCounter>();
        }

        private void OnEnable()
        {
            _coinSpawner.ItemsSpawned += _coinCounter.Init;
        }

        private void OnDisable()
        {
            _coinSpawner.ItemsSpawned -= _coinCounter.Init;
        }
    }
}