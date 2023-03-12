using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [field: SerializeField] private SpawnZone _spawner;
    [field: SerializeField] private InGameUI _inGameUI;
    [field: SerializeField] private EnemiesData _enemiesData;
    [field: SerializeField] private PlayerData _playerData;
    [field: SerializeField] private EnemyFactory _enemyFactory;
    [field: SerializeField] private PlayerFactory _playerFactory;
    [field: SerializeField] private float _easySpawnCooldown = 3f;
    [field: SerializeField] private float _hardSpawnCooldown = 1f;

    private bool _inCooldown = false;
    private bool _gameOver = false;
    private bool _gamePaused = true;
    private float _currentSpawnCooldown;
    private float _timer = 0f;
    private List<Enemy> _enemies = new List<Enemy>();
    private Player _player;

    public static Player Player => _instance._player;
    public static float Timer => _instance._timer;

    private static Game _instance;

    private void Awake()
    {
        _instance = this;

        _currentSpawnCooldown = _easySpawnCooldown;
        _inGameUI.Initialize();
        SpawnPlayer();
        UpdateHealth();
    }

    private void Update()
    {
        if (_gameOver || _gamePaused)
            return;

        _timer += Time.deltaTime;

        _inGameUI.GameUpdate();

        if (!_inCooldown)
            SpawnEnemy();

        _player?.GameUpdate();
        Physics.SyncTransforms();
        UpdateEnemies();
    }

    private void UpdateEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (!_enemies[i].GameUpdate())
            {
                int lastIndex = _enemies.Count - 1;
                _enemies[i] = _enemies[lastIndex];
                _enemies.RemoveAt(lastIndex);
                i--;
            }
        }
    }

    public static void Defeat()
    {
        _instance._player = null;
        _instance.UpdateEnemies();
        _instance._gameOver = true;
        _instance._inGameUI.ShowLosePanel();
    }

    public static void UpdateHealth()
    {
        if (_instance._player == null)
            return;

        _instance._inGameUI.UpdateHealth(Player.Health); 
    }

    public static void SpawnPlayer()
    {
        var player = _instance._playerFactory.Get(_instance._playerData);
        player.transform.position = _instance._spawner.PlayerSpawnpoint;
        _instance._player = player;
    }

    public static void SpawnEnemy()
    {
        var enemy = _instance._enemyFactory.Get(_instance._enemiesData.RandomData);
        enemy.transform.position = _instance._spawner.RandomEnemySpawnpoint;
        _instance._enemies.Add(enemy);

        if (_instance._currentSpawnCooldown >= _instance._hardSpawnCooldown)
            _instance._currentSpawnCooldown -= 0.05f;

        _instance.SpawnCooldown(_instance._currentSpawnCooldown);
    }

    public static void DestroyAllEnemies()
    {
        foreach (Enemy enemy in _instance._enemies)
        {
            if (enemy == null)
                continue;          

            enemy.DestroyEnemy();
        }

        _instance._enemies.Clear();
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        _gamePaused = false;
    }

    private async void SpawnCooldown(float cooldown)
    {
        _inCooldown = true;
        cooldown *= 1000;
        await Task.Delay((int)cooldown);
        _inCooldown = false;
    }
}
