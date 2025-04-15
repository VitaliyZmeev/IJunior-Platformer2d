using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(ItemCollector), typeof(GroundChecker))]
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMover), typeof(PlayerAnimator))]
    public class Player : Actor
    {
        private PlayerStateMachine _stateMachine;
        private PlayerInput _input;
        private PlayerMover _mover;
        private PlayerAnimator _animator;
        private GroundChecker _groundChecker;
        private ItemCollector _itemCollector;

        public PlayerInput Input => _input;
        public PlayerMover Mover => _mover;
        public PlayerAnimator Animator => _animator;
        public GroundChecker GroundChecker => _groundChecker;

        protected override void Awake()
        {
            base.Awake();
            _input = GetComponent<PlayerInput>();
            _mover = GetComponent<PlayerMover>();
            _animator = GetComponent<PlayerAnimator>();
            _groundChecker = GetComponent<GroundChecker>();
            _itemCollector = GetComponent<ItemCollector>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _itemCollector.HealKitCollected += OnHealKitCollected;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _itemCollector.HealKitCollected -= OnHealKitCollected;
        }

        private void Start()
        {
            _stateMachine = new(this);
        }

        private void Update()
        {
            _stateMachine.Update();
            _mover.MoveToDirectionX(0f, _input.GetMoveDirection());
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        public void Init()
        {
            Health.Refresh();
            ActorCollider.Enable();
        }

        private void OnHealKitCollected(HealKit healKit)
        {
            Health.TakeHeal(healKit.Heal);
        }
    }
}