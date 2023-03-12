using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Enemies Data", fileName = "New Enemies Data")]
public class EnemiesData : ScriptableObject
{
    [field: SerializeField] private EnemyData[] _datas;

    public EnemyData[] Datas => _datas;
    public EnemyData RandomData => _datas[Random.Range(0, _datas.Length)];
}

[System.Serializable]
public class EnemyData
{
    public string Name;
    public Enemy Prefab;
    public float Health;
    public float Speed;
    public float Damage;
    public EnemySounds Sounds;
}

[System.Serializable]
public class EnemySounds
{
    public AudioClip[] AttackClips;
    public AudioClip[] DeathClips;

    public AudioClip RandomAttack => AttackClips[Random.Range(0, AttackClips.Length)];
    public AudioClip RandomDeath => DeathClips[Random.Range(0, DeathClips.Length)];
}
