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
            Actor.Animator.AttackFinished += OnAttackFinished;
            Actor.Animator.SetHitTrigger();
        }

        public override void Exit()
        {
            Actor.Animator.AttackFinished -= OnAttackFinished;
        }

        private void OnAttackFinished()
        {
            StateMachine.TransitToState(typeof(MovePlayerState));
        }
    }
}