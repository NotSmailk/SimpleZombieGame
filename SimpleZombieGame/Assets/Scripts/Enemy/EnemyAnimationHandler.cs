using UnityEngine;

public class EnemyAnimationHandler
{
    private Animator _animator;
    private readonly int Death = Animator.StringToHash("Death");
    private readonly int Idle = Animator.StringToHash("ZombieIdle");
    private readonly int Walk = Animator.StringToHash("ZombieWalk");
    private readonly int Attack = Animator.StringToHash("ZombieAttack");

    public void Initialize(Animator animator)
    {
        _animator = animator;
    }

    public void PlayIdle() => _animator.CrossFade(Idle, 0, 0);

    public void PlayChase() => _animator.CrossFade(Walk, 0, 0);

    public void PlayAttack() => _animator.CrossFade(Attack, 0, 0);

    public void PlayDeath() => _animator.CrossFade(Death, 0, 0);
}
