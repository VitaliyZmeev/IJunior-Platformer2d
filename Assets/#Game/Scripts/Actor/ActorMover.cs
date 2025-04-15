using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ActorMover : MonoBehaviour
    {
        [SerializeField] private float _startSpeed = 200f;
        [SerializeField] private Direction _spriteDirection = Direction.Left;

        private float _speed;
        private float _directionX;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;

        public float DirectionX => _directionX;
        public float VelocityY => _rigidbody.velocity.y;
        public Rigidbody2D Rigidbody => _rigidbody;

        private enum Direction
        {
            Left,
            Right
        }

        protected virtual void Awake()
        {
            _speed = _startSpeed;
            _directionX = _spriteDirection == Direction.Left ?
                Vector2.left.x : Vector2.right.x;
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected virtual void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_speed *
                _directionX * Time.fixedDeltaTime, _rigidbody.velocity.y);
        }

        public void MoveToDirectionX(float fromDirX, float toDirX)
        {
            if (fromDirX < toDirX)
                MoveToDirectionX(Vector2.right.x, Direction.Right);
            else if (fromDirX > toDirX)
                MoveToDirectionX(Vector2.left.x, Direction.Left);
            else
                _speed = 0f;
        }

        private void MoveToDirectionX(float axisValue, Direction flipDirection)
        {
            _speed = _startSpeed;
            _directionX = axisValue;
            _spriteRenderer.flipX = _spriteDirection != flipDirection;
        }
    }
}