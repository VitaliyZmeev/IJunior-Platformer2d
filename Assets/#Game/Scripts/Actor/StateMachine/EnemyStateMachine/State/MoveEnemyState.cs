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
            Actor.Animator.SetFollowBool(false);
            MoveToWayPoint();
        }

        public override void FixedUpdate()
        {
            if (Vector2.Distance(Actor.transform.position,
                Actor.Route.CurrentWaypoint.position) <= WayPointTriggerRange)
            {
                Actor.Route.GoToNextPoint();
                MoveToWayPoint();
            }

            if (Actor.DetectFollowTarget() != null)
                StateMachine.TransitToState(typeof(FollowTargetEnemyState));
        }

        private void MoveToWayPoint() => Actor.ActorMover.MoveToDirectionX
            (Actor.transform.position.x, Actor.Route.CurrentWaypoint.position.x);
    }
}