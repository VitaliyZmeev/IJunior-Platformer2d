using System;
using UnityEngine;

namespace HealthViewIJunior
{
    public class TestHealth : MonoBehaviour
    {
        [SerializeField] private int _maxValue = 100;

        private int _value;

        public int MaxValue => _maxValue;

        public event Action Died;
        public event Action<int> ValueChanged;

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
            if (_value + heal <= _maxValue)
            {
                SetValue(_value + heal);
            }
        }

        public void TakeDamage(int damage)
        {
            if (_value > damage)
            {
                SetValue(_value - damage);
            }
            else
            {
                Die();
            }
        }

        private void Die()
        {
            SetValue(0);
            Died?.Invoke();
        }

        private void SetValue(int value)
        {
            _value = value;
            ValueChanged?.Invoke(_value);
        }
    }
}