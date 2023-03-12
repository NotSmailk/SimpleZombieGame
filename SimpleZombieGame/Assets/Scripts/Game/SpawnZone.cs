using System.Threading.Tasks;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [field: SerializeField] private Transform[] _enemiesSpawnpoints;
    [field: SerializeField] private Transform _playerSpawnpoint;

    public Vector3 RandomEnemySpawnpoint => _enemiesSpawnpoints[Random.Range(0, _enemiesSpawnpoints.Length)].position;
    public Vector3 PlayerSpawnpoint => _playerSpawnpoint.position;
}
