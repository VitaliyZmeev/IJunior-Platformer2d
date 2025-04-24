namespace Platformer2d
{
    public class FallPlayerState : State<Player>
    {
        public FallPlayerState(Player actor, StateMachine<Player> stateMachine)
            : base(actor, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Actor.PlayerAnimator.SetFallTrigger();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (Actor.GroundChecker.IsGrounded())
            {
                Actor.PlayerAnimator.SetGroundedBool(true);
                StateMachine.TransitToState(typeof(MovePlayerState));
            }
        }
    }
}