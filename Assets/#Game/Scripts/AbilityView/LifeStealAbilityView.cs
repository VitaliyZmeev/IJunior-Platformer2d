using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(LifeStealAbility), typeof(SpriteRenderer))]
    public class LifeStealAbilityView : MonoBehaviour
    {
        private LifeStealAbility _lifeStealAbility;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _lifeStealAbility = GetComponent<LifeStealAbility>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SetUpSpriteRenderer();
        }

        private void OnEnable()
        {
            _lifeStealAbility.ActionTimer.Started += ToggleAbilityRadiusView;
            _lifeStealAbility.ActionTimer.Finished += ToggleAbilityRadiusView;
        }


        private void OnDisable()
        {
            _lifeStealAbility.ActionTimer.Started -= ToggleAbilityRadiusView;
            _lifeStealAbility.ActionTimer.Finished -= ToggleAbilityRadiusView;
        }

        private void SetUpSpriteRenderer()
        {
            float spriteSizeMultiplier = 2f;
            _spriteRenderer.enabled = false;
            _spriteRenderer.size = _lifeStealAbility.Radius
                * spriteSizeMultiplier * Vector2.one;
        }

        private void ToggleAbilityRadiusView()
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
        }
    }
}