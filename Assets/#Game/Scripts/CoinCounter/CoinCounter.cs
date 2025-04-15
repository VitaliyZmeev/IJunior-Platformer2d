using System;
using UnityEngine;

namespace Platformer2d
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private ItemCollector _itemCollector;

        private int _coins;
        private int _maxCoins;

        public event Action<int> CoinsChanged;
        public event Action<int> MaxCoinsChanged;

        private void OnEnable()
        {
            _itemCollector.CoinCollected += AddCoin;
        }

        private void OnDisable()
        {
            _itemCollector.CoinCollected -= AddCoin;
        }

        public void Init(int maxCoins)
        {
            _maxCoins = maxCoins;
            MaxCoinsChanged?.Invoke(_maxCoins);
        }

        private void AddCoin()
        {
            _coins++;
            CoinsChanged?.Invoke(_coins);
        }
    }
}