using TMPro;
using UnityEngine;

namespace HealthViewIJunior
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HealthDisplay : HealthView
    {
        [SerializeField] private char _splitter;

        private TextMeshProUGUI _display;

        private void Awake()
        {
            _display = GetComponent<TextMeshProUGUI>();
        }

        protected override void OnHealthChanged(int health)
        {
            _display.text = health.ToString() + ' ' + _splitter + ' ' + MaxHealth.ToString();
        }
    }
}