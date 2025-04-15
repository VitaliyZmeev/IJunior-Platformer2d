using System;

namespace Platformer2d
{
    public class Health
    {
        private readonly int _maxValue;

        private int _value;

        public event Action Died;

        public Health(int maxValue)
        {
            _maxValue = maxValue;
            Refresh();
        }

        public void Refresh()
        {
            _value = _maxValue;
        }

        public void TakeHeal(int heal)
        {
            if (_value + heal >= _maxValue)
                Refresh();
            else
                _value += heal;
        }

        public void TakeDamage(int damage)
        {
            if (_value <= damage)
                Die();
            else
                _value -= damage;
        }

        private void Die()
        {
            _value = 0;
            Died?.Invoke();
        }
    }
}