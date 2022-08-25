using UnityEngine;
using UnityEngine.Events;

public class PlayerSoundEffects : MonoBehaviour
{
    [field: SerializeField] private AudioSource m_audioSource;
    [field: SerializeField] private AudioClip[] m_gunFireClips;
    [field: SerializeField] private AudioClip m_hitClip;

    [field: HideInInspector] public UnityEvent OnGunFire = new UnityEvent();
    [field: HideInInspector] public UnityEvent OnGetHit = new UnityEvent();

    private void Awake()
    {
        OnGunFire.AddListener(PlayGunFireClip);
        OnGetHit.AddListener(PlayHitCLip);

        m_audioSource.volume = 0.1f;
    }

    public void PlayHitCLip()
    {
        m_audioSource.PlayOneShot(m_hitClip);
    }

    public void PlayGunFireClip()
    { 
        AudioClip gunFireClip = m_gunFireClips[Random.Range(0, m_gunFireClips.Length)];

        m_audioSource.PlayOneShot(gunFireClip);
    }
}
