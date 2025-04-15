using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(EnemyRoute), typeof(EnemyMover), typeof(EnemyAnimator))]
    public class Enemy : Actor
    {
        [SerializeField] private float _followRange = 10f;

        private EnemyRoute _route;
        private EnemyMover _mover;
        private EnemyAnimator _animator;
        private EnemyStateMachine _stateMachine;

        public EnemyRoute Route => _route;
        public EnemyMover Mover => _mover;
        public EnemyAnimator Animator => _animator;

        protected override void Awake()
        {
            base.Awake();
            _route = GetComponent<EnemyRoute>();
            _mover = GetComponent<EnemyMover>();
            _animator = GetComponent<EnemyAnimator>();
        }

        private void Start()
        {
            _stateMachine = new(this);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        public Player DetectFollowTarget()
        {
            return DetectPlayer(_followRange);
        }

        public Player DetectAttackTarget()
        {
            return DetectPlayer(RangeAttack);
        }

        private Player DetectPlayer(float range)
        {
            Actor actor = TargetDetector.DetectActor(range);

            if (actor is Player player)
                return player;

            return default;
        }

        protected override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }
    }
}