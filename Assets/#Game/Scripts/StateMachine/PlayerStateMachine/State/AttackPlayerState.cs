namespace Platformer2d
{
    public class AttackPlayerState : State<Player>
    {
        public AttackPlayerState(Player actor, StateMachine<Player> stateMachine)
            : base(actor, stateMachine)
        {
        }

        public override void Enter()
        {
            Actor.PlayerAnimator.AttackFinished += OnAttackFinished;
            Actor.PlayerAnimator.SetHitTrigger();
        }

        public override void Exit()
        {
            Actor.PlayerAnimator.AttackFinished -= OnAttackFinished;
        }

        private void OnAttackFinished()
        {
            StateMachine.TransitToState(typeof(MovePlayerState));
        }
    }
}