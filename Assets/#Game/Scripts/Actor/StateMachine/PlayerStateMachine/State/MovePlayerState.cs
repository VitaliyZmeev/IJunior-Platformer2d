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
            Actor.Input.HitPerformed += OnHitPerformed;
        }

        public override void Exit()
        {
            base.Exit();
            Actor.Input.HitPerformed -= OnHitPerformed;
        }

        public override void Update()
        {
            base.Update();
            Actor.Animator.SetMoveFloat(Actor.Input.GetMoveDirection());
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (Actor.Input.IsJump() && Actor.GroundChecker.IsGrounded())
                StateMachine.TransitToState(typeof(JumpPlayerState));
        }

        private void OnHitPerformed()
        {
            StateMachine.TransitToState(typeof(AttackPlayerState));
        }
    }
}