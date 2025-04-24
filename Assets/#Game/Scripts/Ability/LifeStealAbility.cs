using System;
using UnityEngine;

namespace Platformer2d
{
    public class LifeStealAbility : Ability
    {
        [SerializeField] private float _radius = 4f;
        [SerializeField] private int _amountLifeSteal = 2;
        [SerializeField] private LayerMask _enemyLayerMask;

        public float Radius => _radius;

        public event Action<int> HealthStolen;

        protected override void InvokeAbilityAction()
        {
            Enemy enemy = DetectLifeStealTarget();

            if (enemy != null)
                StealLife(enemy);
        }

        private Enemy DetectLifeStealTarget()
        {
            Enemy target = default;
            float targetDistance = float.MaxValue;
            Collider2D[] colliders = Physics2D.OverlapCircleAll
                (transform.position, _radius, _enemyLayerMask);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    float currentEnemyDistance = Vector2.Distance(transform.position,
                        enemy.transform.position);

                    if (currentEnemyDistance <= targetDistance)
                    {
                        targetDistance = currentEnemyDistance;
                        target = enemy;
                    }
                }
            }

            return target;
        }

        private void StealLife(Enemy enemy)
        {
            int enemyHealth = enemy.Health.Value;

            if (enemyHealth <= 0)
                return;

            enemy.Health.TakeDamage(_amountLifeSteal);

            if (enemyHealth >= _amountLifeSteal)
                HealthStolen?.Invoke(_amountLifeSteal);
            else
                HealthStolen?.Invoke(enemyHealth);
        }
    }
}