using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(ActorMover))]
    public class ActorDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetActorLayerMask;

        private ActorMover _actorMover;

        private void Awake()
        {
            _actorMover = GetComponent<ActorMover>();
        }

        public Actor DetectActor(float detectRange)
        {
            RaycastHit2D rayCastHit = Physics2D.Raycast(transform.position + Vector3.up,
                new Vector2(_actorMover.DirectionX, 0f), detectRange, _targetActorLayerMask);
            Collider2D collider = rayCastHit.collider;

            if (collider != null)
                if (collider.TryGetComponent(out Actor target))
                    return target;

            return default;
        }
    }
}