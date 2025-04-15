using System;
using UnityEngine;

namespace Platformer2d
{
    public class ItemCollector : MonoBehaviour
    {
        public event Action CoinCollected;
        public event Action<HealKit> HealKitCollected;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Item item))
            {
                item.Collect();

                if (item is Coin)
                    CoinCollected?.Invoke();
                else if (item is HealKit healKit)
                    HealKitCollected?.Invoke(healKit);
            }
        }
    }
}