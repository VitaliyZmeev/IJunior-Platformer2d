using TMPro;
using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(CoinCounter))]
    public class CoinCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsDisplay;
        [SerializeField] private TextMeshProUGUI _maxCoinsDisplay;

        private CoinCounter _coinCounter;

        private void Awake()
        {
            _coinCounter = GetComponent<CoinCounter>();
        }

        private void OnEnable()
        {
            _coinCounter.CoinsChanged += ShowCoins;
            _coinCounter.MaxCoinsChanged += ShowMaxCoins;
        }

        private void OnDisable()
        {
            _coinCounter.CoinsChanged -= ShowCoins;
            _coinCounter.MaxCoinsChanged -= ShowMaxCoins;
        }

        private void ShowCoins(int coins)
        {
            _coinsDisplay.text = coins.ToString();
        }

        private void ShowMaxCoins(int maxCoins)
        {
            _maxCoinsDisplay.text = maxCoins.ToString();
        }
    }
}