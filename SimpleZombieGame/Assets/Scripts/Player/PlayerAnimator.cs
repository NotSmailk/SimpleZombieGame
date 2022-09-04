using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_animator;

    private int Idle = Animator.StringToHash("PlayerIdle");
    private int Death = Animator.StringToHash("Death");

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        m_animator.CrossFade(Idle, 0, 0);
    }

    public void PlayDeath()
    {
        m_animator.CrossFade(Death, 0, 0);
    }
}
