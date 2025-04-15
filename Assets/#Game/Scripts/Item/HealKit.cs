using UnityEngine;

namespace Platformer2d
{
    public class HealKit : Item
    {
        [SerializeField] private int _heal = 2;

        public int Heal => _heal;
    }
}