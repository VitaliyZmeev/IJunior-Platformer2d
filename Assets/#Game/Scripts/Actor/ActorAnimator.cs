using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class ActorAnimator : MonoBehaviour
{
    private readonly int Hurt = Animator.StringToHash(nameof(Hurt));
    private readonly int Death = Animator.StringToHash(nameof(Death));

    private Animator _animator;

    public Animator Animator => _animator;

    public event Action HitFinished;
    public event Action AttackFinished;
    public event Action DeathFinished;

    private void Awake() => _animator = GetComponent<Animator>();

    public void SetHurtTrigger() => _animator.SetTrigger(Hurt);

    public void SetDeathTrigger() => _animator.SetTrigger(Death);

    public void OnHitFinished() => HitFinished?.Invoke();

    public void OnAttackFinished() => AttackFinished?.Invoke();

    public void OnDeathFinished() => DeathFinished?.Invoke();
}