using UnityEngine;
using UnityEngine.Events;

public class PlayerSFX
{
    private AudioSource _audioSource;
    private PlayerSounds _sounds;

    public void Initialize(AudioSource audioSource, PlayerSounds playerSounds)
    {
        _audioSource = audioSource;
        _sounds = playerSounds;
        _audioSource.volume = 0.1f;
    }

    public void PlayHitCLip()
    {
        _audioSource.PlayOneShot(_sounds.HitClip);
    }

    public void PlayGunFireClip()
    { 
        AudioClip gunFireClip = _sounds.RandomGunFireClip;
        _audioSource.PlayOneShot(gunFireClip);
    }
}
