using UnityEngine;

namespace Platformer2d
{
    public class EnemyAnimator : ActorAnimator
    {
        private readonly int Follow = Animator.StringToHash(nameof(Follow));
        private readonly int Attack = Animator.StringToHash(nameof(Attack));

        public void SetFollowBool(bool value) =>
            Animator.SetBool(Follow, value);

        public void SetAttackBool(bool value) =>
            Animator.SetBool(Attack, value);
    }
}