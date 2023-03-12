using UnityEngine;

public class EnemySFX
{
    private AudioSource _source;
    private EnemySounds _sounds;

    public void Initialize(AudioSource audioSource, EnemySounds sounds)
    {
        _source = audioSource;
        _sounds = sounds;
        _source.volume = 0.1f;
    }

    public void PlayAttackCLip()
    {
        AudioClip attackClip = _sounds.RandomAttack;
        _source.PlayOneShot(attackClip);
    }

    public void PlayDeathClip()
    {
        AudioClip deathClip = _sounds.RandomDeath;
        _source.PlayOneShot(deathClip);
    }
}
