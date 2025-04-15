using UnityEngine;

namespace Platformer2d
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private float GroundedDistance = 0.1f;
        [SerializeField] private LayerMask _groundLayerMask;

        public bool IsGrounded() =>
            Physics2D.Raycast(transform.position, Vector2.down,
                GroundedDistance, _groundLayerMask);
    }
}