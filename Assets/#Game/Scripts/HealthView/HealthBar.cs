using UnityEngine;
using UnityEngine.UI;

namespace HealthViewIJunior
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : HealthView
    {
        private Slider _bar;

        protected Slider Bar => _bar;

        private void Awake()
        {
            _bar = GetComponent<Slider>();
        }

        protected override void OnHealthChanged(int health)
        {
            _bar.value = GetNormalizedHealth(health);
        }

        protected float GetNormalizedHealth(int health)
        {
            return health / (float)MaxHealth;
        }
    }
}