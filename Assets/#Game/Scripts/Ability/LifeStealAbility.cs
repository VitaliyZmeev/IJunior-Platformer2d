using System;
using UnityEngine;

namespace Platformer2d
{
    public class LifeStealAbility : Ability
    {
        [SerializeField] private float _radius = 4f;
        [SerializeField] private int _maxTargets = 10;
        [SerializeField] private int _amountLifeSteal = 2;
        [SerializeField] private LayerMask _enemyLayerMask;

        private Collider2D[] _targetColliders;

        public float Radius => _radius;

        public event Action<int> HealthStolen;

        private void Awake()
        {
            _targetColliders = new Collider2D[_maxTargets];
        }

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
            int targetColliders = Physics2D.OverlapCircleNonAlloc
                (transform.position, _radius, _targetColliders, _enemyLayerMask);

            for (int i = 0; i < targetColliders; i++)
            {
                if (_targetColliders[i].TryGetComponent(out Enemy enemy))
                {
                    float currentEnemyDistance = (transform.position -
                        enemy.transform.position).sqrMagnitude;

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