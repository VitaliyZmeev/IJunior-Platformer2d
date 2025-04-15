namespace Platformer2d
{
    public class EnemyMover : ActorMover
    {
        private bool _canMove = true;

        protected override void FixedUpdate()
        {
            if (_canMove)
            {
                base.FixedUpdate();
            }
        }

        public void StopMove() => _canMove = false;

        public void ContinueMove() => _canMove = true;
    }
}