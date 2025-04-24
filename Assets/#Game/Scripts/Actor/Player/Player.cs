using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(ItemCollector), typeof(GroundChecker))]
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMover), typeof(PlayerAnimator))]
    public class Player : Actor
    {
        [SerializeField] private LifeStealAbility _lifeStealAbility;

        private PlayerInput _playerInput;
        private PlayerMover _playerMover;
        private PlayerAnimator _playerAnimator;
        private GroundChecker _groundChecker;
        private ItemCollector _itemCollector;
        private PlayerStateMachine _playerStateMachine;

        public PlayerInput PlayerInput => _playerInput;
        public PlayerMover PlayerMover => _playerMover;
        public PlayerAnimator PlayerAnimator => _playerAnimator;
        public GroundChecker GroundChecker => _groundChecker;

        protected override void Awake()
        {
            base.Awake();
            _playerInput = GetComponent<PlayerInput>();
            _playerMover = GetComponent<PlayerMover>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _groundChecker = GetComponent<GroundChecker>();
            _itemCollector = GetComponent<ItemCollector>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _itemCollector.HealKitCollected += OnHealKitCollected;
            _playerInput.LifeStealAbilityPerformed += ActivateLifeStealAbility;
            _lifeStealAbility.HealthStolen += Health.TakeHeal;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _itemCollector.HealKitCollected -= OnHealKitCollected;
            _playerInput.LifeStealAbilityPerformed -= ActivateLifeStealAbility;
            _lifeStealAbility.HealthStolen += Health.TakeHeal;
        }

        private void Start()
        {
            _playerStateMachine = new(this);
        }

        private void Update()
        {
            _playerStateMachine.Update();
            _playerMover.MoveToDirectionX(0f, _playerInput.GetMoveDirection());
        }

        private void FixedUpdate()
        {
            _playerStateMachine.FixedUpdate();
        }

        public void Init()
        {
            Health.Refresh();
            Rigidbody.Enable();
        }

        private void OnHealKitCollected(HealKit healKit)
        {
            Health.TakeHeal(healKit.Heal);
        }

        private void ActivateLifeStealAbility()
        {
            _lifeStealAbility.Activate();
        }
    }
}