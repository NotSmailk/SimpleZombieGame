using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Player Data", fileName = "New Player Data")]
public class PlayerData : ScriptableObject
{
    public Player Prefab;
    public float Health;
    public float Damage;
    public Bullet BulletPrefab;
    public PlayerSounds Sounds;
}

[System.Serializable]
public class PlayerSounds
{
    public AudioClip[] GunFireClips;
    public AudioClip HitClip;

    public AudioClip RandomGunFireClip => GunFireClips[Random.Range(0, GunFireClips.Length)];
}
