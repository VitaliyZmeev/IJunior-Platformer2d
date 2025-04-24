using System;
using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(ActorMover), typeof(ActorDetector), typeof(ActorRigidbody))]
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] private int _damageAttack = 1;
        [SerializeField] private float _rangeAttack = 4f;

        private Health _health;
        private ActorMover _mover;
        private ActorRigidbody _rigidbody;
        private ActorAnimator _animator;
        private ActorDetector _targetDetector;

        protected float RangeAttack => _rangeAttack;

        public Health Health => _health;
        public ActorMover Mover => _mover;
        public ActorRigidbody Rigidbody => _rigidbody;
        public ActorDetector TargetDetector => _targetDetector;

        public event Action Died;

        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
            _mover = GetComponent<ActorMover>();
            _rigidbody = GetComponent<ActorRigidbody>();
            _animator = GetComponent<ActorAnimator>();
            _targetDetector = GetComponent<ActorDetector>();
        }

        protected virtual void OnEnable()
        {
            _health.Died += StartDie;
            _animator.HitFinished += AttackTarget;
            _animator.DeathFinished += Die;
        }

        protected virtual void OnDisable()
        {
            _health.Died -= StartDie;
            _animator.HitFinished -= AttackTarget;
            _animator.DeathFinished -= Die;
        }

        protected virtual void Die()
        {
            Died?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            _animator.SetHurtTrigger();
        }

        private void AttackTarget()
        {
            Actor attackTarget = _targetDetector.DetectActor(_rangeAttack);

            if (attackTarget != null)
                attackTarget.TakeDamage(_damageAttack);
        }

        private void StartDie()
        {
            _rigidbody.Disable();
            _animator.SetDeathTrigger();
        }
    }
}