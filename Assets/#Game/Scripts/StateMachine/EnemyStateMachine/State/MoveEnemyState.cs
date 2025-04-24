using UnityEngine;

namespace Platformer2d
{
    public class MoveEnemyState : State<Enemy>
    {
        private const float WayPointTriggerRange = 1f;

        public MoveEnemyState(Enemy enemy, StateMachine<Enemy> stateMachine)
            : base(enemy, stateMachine) { }

        public override void Enter()
        {
            Actor.EnemyAnimator.SetFollowBool(false);
            Actor.Rigidbody.SetExcludeLayerMask(nameof(Enemy));
            MoveToWayPoint();
        }

        public override void FixedUpdate()
        {
            if (Vector2.Distance(Actor.transform.position,
                Actor.EnemyRoute.CurrentWaypoint.position) <= WayPointTriggerRange)
            {
                Actor.EnemyRoute.GoToNextPoint();
                MoveToWayPoint();
            }

            if (Actor.DetectFollowTarget() != null)
                StateMachine.TransitToState(typeof(FollowTargetEnemyState));
        }

        private void MoveToWayPoint() => Actor.Mover.MoveToDirectionX
            (Actor.transform.position.x, Actor.EnemyRoute.CurrentWaypoint.position.x);
    }
}