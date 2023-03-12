using UnityEngine;

public class PlayerAnimationHandler
{
    private Animator _animator;

    private int Idle = Animator.StringToHash("PlayerIdle");
    private int Death = Animator.StringToHash("Death");

    public void Initialize(Animator animator)
    {
        _animator = animator;
        _animator.CrossFade(Idle, 0, 0);
    }

    public void PlayDeath()
    {
        _animator.CrossFade(Death, 0, 0);
    }
}
