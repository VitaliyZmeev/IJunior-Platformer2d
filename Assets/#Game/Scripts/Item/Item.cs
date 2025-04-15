using System;
using UnityEngine;

namespace Platformer2d
{
    public abstract class Item : MonoBehaviour
    {
        public event Action<Item> Collected;

        public virtual void Collect()
        {
            Collected?.Invoke(this);
        }
    }
}