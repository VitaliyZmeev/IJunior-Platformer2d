using UnityEngine;

namespace Platformer2d
{
    public class PlayerAnimator : ActorAnimator
    {
        private readonly int Move = Animator.StringToHash(nameof(Move));
        private readonly int Grounded = Animator.StringToHash(nameof(Grounded));
        private readonly int Fall = Animator.StringToHash(nameof(Fall));
        private readonly int Hit = Animator.StringToHash(nameof(Hit));

        public void SetMoveFloat(float horizontalDirection) =>
            Animator.SetFloat(Move, horizontalDirection);

        public void SetGroundedBool(bool value) => Animator.SetBool(Grounded, value);

        public void SetFallTrigger() => Animator.SetTrigger(Fall);

        public void SetHitTrigger() => Animator.SetTrigger(Hit);
    }
}