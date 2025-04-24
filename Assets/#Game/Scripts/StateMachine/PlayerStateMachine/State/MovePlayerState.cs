namespace Platformer2d
{
    public class MovePlayerState : State<Player>
    {
        public MovePlayerState(Player actor, StateMachine<Player> stateMachine)
            : base(actor, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Actor.PlayerInput.HitPerformed += OnHitPerformed;
        }

        public override void Exit()
        {
            base.Exit();
            Actor.PlayerInput.HitPerformed -= OnHitPerformed;
        }

        public override void Update()
        {
            base.Update();
            Actor.PlayerAnimator.SetMoveFloat(Actor.PlayerInput.GetMoveDirection());
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (Actor.PlayerInput.IsJump() && Actor.GroundChecker.IsGrounded())
                StateMachine.TransitToState(typeof(JumpPlayerState));
        }

        private void OnHitPerformed()
        {
            StateMachine.TransitToState(typeof(AttackPlayerState));
        }
    }
}