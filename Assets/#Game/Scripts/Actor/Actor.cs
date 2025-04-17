using System;
using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(ActorMover), typeof(ActorDetector), typeof(ActorCollider))]
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] private int _damageAttack = 1;
        [SerializeField] private float _rangeAttack = 4f;

        private Health _health;
        private ActorMover _actorMover;
        private ActorCollider _actorCollider;
        private ActorAnimator _actorAnimator;
        private ActorDetector _targetDetector;

        protected float RangeAttack => _rangeAttack;

        public Health Health => _health;
        public ActorMover ActorMover => _actorMover;
        public ActorCollider ActorCollider => _actorCollider;
        public ActorDetector TargetDetector => _targetDetector;

        public event Action Died;

        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
            _actorMover = GetComponent<ActorMover>();
            _actorCollider = GetComponent<ActorCollider>();
            _actorAnimator = GetComponent<ActorAnimator>();
            _targetDetector = GetComponent<ActorDetector>();
        }

        protected virtual void OnEnable()
        {
            _health.Died += StartDie;
            _actorAnimator.HitFinished += AttackTarget;
            _actorAnimator.DeathFinished += Die;
        }

        protected virtual void OnDisable()
        {
            _health.Died -= StartDie;
            _actorAnimator.HitFinished -= AttackTarget;
            _actorAnimator.DeathFinished -= Die;
        }

        protected virtual void Die()
        {
            Died?.Invoke();
        }

        private void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            _actorAnimator.SetHurtTrigger();
        }

        private void AttackTarget()
        {
            Actor attackTarget = _targetDetector.DetectActor(_rangeAttack);

            if (attackTarget != null)
                attackTarget.TakeDamage(_damageAttack);
        }

        private void StartDie()
        {
            _actorCollider.Disable();
            _actorAnimator.SetDeathTrigger();
        }
    }
}