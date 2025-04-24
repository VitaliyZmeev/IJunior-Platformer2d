using Platformer2d;
using UnityEngine;

namespace HealthViewIJunior
{
    public abstract class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;

        protected int MaxHealth => _health.MaxValue;

        private void OnEnable()
        {
            _health.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.Changed -= OnHealthChanged;
        }

        protected abstract void OnHealthChanged(int health);
    }
}