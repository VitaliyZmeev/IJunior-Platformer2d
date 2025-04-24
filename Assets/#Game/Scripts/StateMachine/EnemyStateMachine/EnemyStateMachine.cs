namespace Platformer2d
{
    public class EnemyStateMachine : StateMachine<Enemy>
    {
        public EnemyStateMachine(Enemy enemy)
        {
            AddStates(enemy);
            SetState(typeof(MoveEnemyState));
        }

        public override void AddStates(Enemy enemy)
        {
            AddState(new MoveEnemyState(enemy, this));
            AddState(new FollowTargetEnemyState(enemy, this));
            AddState(new AttackEnemyState(enemy, this));
        }
    }
}