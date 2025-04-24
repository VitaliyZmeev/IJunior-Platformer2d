using System.Collections;
using UnityEngine;

namespace Platformer2d
{
    public abstract class Ability : MonoBehaviour
    {
        [SerializeField] private Timer _actionTimer;
        [SerializeField] private Timer _cooldownTimer;
        [SerializeField] private float _duration = 6f;
        [SerializeField] private float _cooldown = 4f;

        private bool _isActive;

        public Timer ActionTimer => _actionTimer;
        public Timer CooldownTimer => _cooldownTimer;

        private void OnEnable()
        {
            _actionTimer.Updated += InvokeAbilityAction;
        }

        private void OnDisable()
        {
            _actionTimer.Updated -= InvokeAbilityAction;
        }

        protected abstract void InvokeAbilityAction();

        public void Activate()
        {
            if (_isActive == false)
            {
                _isActive = true;
                StartCoroutine(RunAction());
            }
        }

        private IEnumerator RunAction()
        {
            yield return _actionTimer.Run(_duration);

            StartCoroutine(RunCooldown());
        }

        private IEnumerator RunCooldown()
        {
            yield return _cooldownTimer.Run(_cooldown);

            _isActive = false;
        }
    }
}