using UnityEngine;
using UnityEngine.Events;

public class EnemySoundEffects : MonoBehaviour
{
    [field: SerializeField] private AudioSource m_audioSource;
    [field: SerializeField] private AudioClip[] m_attackClips;
    [field: SerializeField] private AudioClip[] m_deathClip;

    [field: HideInInspector] public UnityEvent OnAttack = new UnityEvent();
    [field: HideInInspector] public UnityEvent OnDeath = new UnityEvent();

    private void Awake()
    {
        OnAttack.AddListener(PlayAttackCLip);
        OnDeath.AddListener(PlayDeathClip);

        m_audioSource.volume = 0.1f;
    }

    public void PlayAttackCLip()
    {
        AudioClip attackClip = m_attackClips[Random.Range(0, m_attackClips.Length)];

        m_audioSource.PlayOneShot(attackClip);
    }

    public void PlayDeathClip()
    {
        AudioClip deathClip = m_deathClip[Random.Range(0, m_deathClip.Length)];

        m_audioSource.PlayOneShot(deathClip);
    }
}
