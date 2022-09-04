using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator m_animator;

    private int Idle = Animator.StringToHash("PlayerIdle");
    private int Death = Animator.StringToHash("Death");
    private int StrafeLeft = Animator.StringToHash("PlayerStrafeLeft");
    private int StrafeRight = Animator.StringToHash("PlayerStrafeRight");

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    public void SetState(int leftValue, int rightValue)
    {
        int value = leftValue - rightValue;

        int state = value == 0 ? Idle : value > 0 ? StrafeLeft : StrafeRight;

        m_animator.CrossFade(state, 0, 0);
    }

    public void PlayDeath()
    {
        m_animator.CrossFade(Death, 0, 0);
    }
}
