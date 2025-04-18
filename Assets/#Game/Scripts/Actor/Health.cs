using System;
using UnityEngine;

namespace Platformer2d
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxValue = 3;

        private int _value;

        public int MaxValue => _maxValue;

        public event Action Died;
        public event Action<int> Changed;

        private void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            SetValue(_maxValue);
        }

        public void TakeHeal(int heal)
        {
            if (heal < 0)
                return;

            SetValue(_value + heal);
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                return;

            if (damage >= _value)
                Died?.Invoke();

            SetValue(_value - damage);
        }

        private void SetValue(int value)
        {
            _value = Mathf.Clamp(value, 0, _maxValue);
            Changed?.Invoke(_value);
        }
    }
}