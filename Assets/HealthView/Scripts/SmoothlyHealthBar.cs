using System.Collections;
using UnityEngine;

namespace HealthViewIJunior
{
    public class SmoothlyHealthBar : HealthBar
    {
        [SerializeField, Range(0, 1)] private float _deltaHealthChange = 0.1f;

        private Coroutine _coroutine;

        protected override void OnHealthChanged(int health)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(SmoothlyChangeHealth(health));
        }

        private IEnumerator SmoothlyChangeHealth(int targetHealth)
        {
            float normalizedTargetHealth = GetNormalizedHealth(targetHealth);

            while (Bar.value != normalizedTargetHealth)
            {
                Bar.value = Mathf.MoveTowards(Bar.value,
                    normalizedTargetHealth, _deltaHealthChange * Time.deltaTime);

                yield return null;
            }
        }
    }
}