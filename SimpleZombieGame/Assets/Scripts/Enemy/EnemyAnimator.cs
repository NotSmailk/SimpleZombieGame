using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator m_animator;

    private readonly int Death = Animator.StringToHash("Death");
    private readonly int Idle = Animator.StringToHash("ZombieIdle");
    private readonly int Walk = Animator.StringToHash("ZombieWalk");
    private readonly int Attack = Animator.StringToHash("ZombieAttack");

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    public void PlayIdle()
    {
        m_animator.CrossFade(Idle, 0, 0);
    }

    public void PlayChase()
    {
        m_animator.CrossFade(Walk, 0, 0);
    }

    public void PlayAttack()
    {
        m_animator.CrossFade(Attack, 0, 0);
    }

    public void PlayDeath()
    {
        m_animator.CrossFade(Death, 0, 0);
    }

    public float GetCurrentAnimationTime()
    {
        return m_animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
