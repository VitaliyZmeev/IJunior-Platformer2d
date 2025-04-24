using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer2d
{
    public class LifeStealAbilityIcon : MonoBehaviour
    {
        private const float MaxFillValue = 1f;
        private const string CooldownValueFormat = "0";

        [SerializeField] private Image _fillLayout;
        [SerializeField] private TextMeshProUGUI _counter;
        [SerializeField] private LifeStealAbility _lifeStealAbility;

        private void OnEnable()
        {
            _lifeStealAbility.CooldownTimer.Started += EnableCooldownDisplay;
            _lifeStealAbility.CooldownTimer.Finished += DisableCooldownDisplay;
            _lifeStealAbility.CooldownTimer.TimeChanged += UpdateCooldownDisplay;
        }

        private void OnDisable()
        {
            _lifeStealAbility.CooldownTimer.Started -= EnableCooldownDisplay;
            _lifeStealAbility.CooldownTimer.Finished -= DisableCooldownDisplay;
            _lifeStealAbility.CooldownTimer.TimeChanged -= UpdateCooldownDisplay;
        }

        private void EnableCooldownDisplay()
        {
            _counter.enabled = true;
            _fillLayout.enabled = true;
            _fillLayout.fillAmount = MaxFillValue;
        }

        private void DisableCooldownDisplay()
        {
            _counter.enabled = false;
            _fillLayout.enabled = false;
        }

        private void UpdateCooldownDisplay(float cooldown)
        {
            _counter.text = cooldown.ToString(CooldownValueFormat);
            _fillLayout.fillAmount = cooldown / _lifeStealAbility.CooldownTimer.Duration;
        }
    }
}