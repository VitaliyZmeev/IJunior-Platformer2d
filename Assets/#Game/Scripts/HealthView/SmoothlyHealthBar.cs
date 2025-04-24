using System.Collections;
using UnityEngine;

namespace HealthViewIJunior
{
    public class SmoothlyHealthBar : HealthBar
    {
        [SerializeField] private float _changeDuration = 1f;

        private Coroutine _coroutine;

        protected override void OnHealthChanged(int health)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(SmoothlyChangeHealth(health));
        }

        private IEnumerator SmoothlyChangeHealth(int targetHealth)
        {
            float time = 0f;
            float startHealth = Bar.value;
            float targetNormalizedHealth = GetNormalizedHealth(targetHealth);

            while (time < _changeDuration)
            {
                time += Time.deltaTime;

                float changeProgress = time / _changeDuration;
                Bar.value = Mathf.Lerp(startHealth, targetNormalizedHealth, changeProgress);

                yield return null;
            }
        }
    }
}