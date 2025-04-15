namespace Platformer2d
{
    public class JumpPlayerState : State<Player>
    {
        public JumpPlayerState(Player actor, StateMachine<Player> stateMachine)
            : base(actor, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Actor.Mover.Jump();
            Actor.Animator.SetGroundedBool(false);
        }

        public override void Update()
        {
            base.Update();

            if (Actor.Mover.VelocityY < 0)
            {
                StateMachine.TransitToState(typeof(FallPlayerState));
            }
        }
    }
}