namespace Platformer2d
{
    public class FollowTargetEnemyState : State<Enemy>
    {
        public FollowTargetEnemyState(Enemy actor, StateMachine<Enemy> stateMachine)
            : base(actor, stateMachine)
        {
        }

        public override void Enter()
        {
            Actor.Animator.SetFollowBool(true);
        }

        public override void FixedUpdate()
        {
            FollowTarget();
            StartAttackTarget();
        }

        private void FollowTarget()
        {
            Player followTarget = Actor.DetectFollowTarget();

            if (followTarget != null)
                Actor.ActorMover.MoveToDirectionX(Actor.transform.position.x,
                    followTarget.transform.position.x);
            else
                StateMachine.TransitToState(typeof(MoveEnemyState));
        }

        private void StartAttackTarget()
        {
            Player attackTarget = Actor.DetectAttackTarget();

            if (attackTarget != null)
                StateMachine.TransitToState(typeof(AttackEnemyState));
        }
    }
}