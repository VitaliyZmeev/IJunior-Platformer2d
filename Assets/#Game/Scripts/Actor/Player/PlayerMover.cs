using UnityEngine;

namespace Platformer2d
{
    public class PlayerMover : ActorMover
    {
        [SerializeField] private float _jumpForce;

        public void Jump() => Rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}