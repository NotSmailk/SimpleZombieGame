using System.Threading.Tasks;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [field: SerializeField] private Transform[] m_enemiesSpawns;
    [field: SerializeField] private EnemyComponents[] m_enemiesPrefabs;
    [field: SerializeField] private float m_easySpawnCooldown = 3f;
    [field: SerializeField] private float m_hardSpawnCooldown = 1f;

    private bool m_inCooldown = false;
    private float m_currentSpawnCooldown;

    private void Start()
    {
        m_currentSpawnCooldown = m_easySpawnCooldown;
    }

    private void Update()
    {
        if (!m_inCooldown && !LevelManager.GameOver)
            SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, m_enemiesPrefabs.Length);
        int enemySpawnIndex = Random.Range(0, m_enemiesSpawns.Length);

        EnemyComponents enemy = Instantiate(m_enemiesPrefabs[enemyIndex], m_enemiesSpawns[enemySpawnIndex].position, Quaternion.identity);

        LevelManager.AddEnemy(enemy);

        if (m_currentSpawnCooldown >= m_hardSpawnCooldown)
            m_currentSpawnCooldown -= 0.05f;

        SpawnCooldown(m_currentSpawnCooldown);
    }

    public async void SpawnCooldown(float cooldown)
    {
        m_inCooldown = true;

        cooldown *= 1000;

        await Task.Delay((int)cooldown);

        m_inCooldown = false;
    }
}
