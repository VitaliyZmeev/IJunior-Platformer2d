using UnityEngine;
using UnityEngine.UI;

namespace Platformer2d
{
    [RequireComponent(typeof(Slider))]
    public class LifeStealAbilityBar : MonoBehaviour
    {
        [SerializeField] private LifeStealAbility _lifeStealAbility;

        private Slider _bar;

        private void Awake()
        {
            _bar = GetComponent<Slider>();
            _bar.value = _bar.maxValue;
        }

        private void OnEnable()
        {
            _lifeStealAbility.ActionTimer.TimeChanged += UpdateActionTime;
            _lifeStealAbility.CooldownTimer.TimeChanged += UpdateCooldownTime;
        }

        private void OnDisable()
        {
            _lifeStealAbility.ActionTimer.TimeChanged -= UpdateActionTime;
            _lifeStealAbility.CooldownTimer.TimeChanged -= UpdateCooldownTime;
        }

        private void UpdateActionTime(float actionTime)
        {
            _bar.value = NormalizeValue(actionTime, _lifeStealAbility.ActionTimer.Duration);
        }

        private void UpdateCooldownTime(float cooldownTime)
        {
            _bar.value = NormalizeValue(_lifeStealAbility.CooldownTimer.Duration -
                cooldownTime, _lifeStealAbility.CooldownTimer.Duration);
        }

        private float NormalizeValue(float value, float maxValue)
        {
            return value / maxValue;
        }
    }
}