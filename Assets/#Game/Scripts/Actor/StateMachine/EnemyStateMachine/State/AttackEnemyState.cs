namespace Platformer2d
{
    public class AttackEnemyState : State<Enemy>
    {
        private Player _player;

        public AttackEnemyState(Enemy actor, StateMachine<Enemy> stateMachine)
            : base(actor, stateMachine) { }

        public override void Enter()
        {
            _player = Actor.DetectFollowTarget();
            _player.Died += OnTargetDie;

            Actor.Mover.StopMove();
            Actor.Animator.SetAttackBool(true);
        }

        public override void FixedUpdate()
        {
            if (Actor.DetectAttackTarget() == null)
                StateMachine.TransitToState(typeof(FollowTargetEnemyState));
        }

        public override void Exit()
        {
            _player.Died -= OnTargetDie;

            Actor.Mover.ContinueMove();
            Actor.Animator.SetAttackBool(false);
        }

        private void OnTargetDie()
        {
            StateMachine.TransitToState(typeof(MoveEnemyState));
        }
    }
}