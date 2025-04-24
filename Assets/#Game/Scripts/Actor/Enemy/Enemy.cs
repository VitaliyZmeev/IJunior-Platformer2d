using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(EnemyRoute), typeof(EnemyMover), typeof(EnemyAnimator))]
    public class Enemy : Actor
    {
        [SerializeField] private float _followRange = 10f;

        private EnemyRoute _enemyRoute;
        private EnemyMover _enemyMover;
        private EnemyAnimator _enemyAnimator;
        private EnemyStateMachine _enemyStateMachine;

        public EnemyRoute EnemyRoute => _enemyRoute;
        public EnemyMover EnemyMover => _enemyMover;
        public EnemyAnimator EnemyAnimator => _enemyAnimator;

        protected override void Awake()
        {
            base.Awake();
            _enemyRoute = GetComponent<EnemyRoute>();
            _enemyMover = GetComponent<EnemyMover>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
        }

        private void Start()
        {
            _enemyStateMachine = new(this);
        }

        private void Update()
        {
            _enemyStateMachine.Update();
        }

        private void FixedUpdate()
        {
            _enemyStateMachine.FixedUpdate();
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