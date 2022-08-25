using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI m_timerText;
    [field: SerializeField] private TextMeshProUGUI m_hpText;
    [field: SerializeField] private Button m_destroyAllEnemiesButton;

    [field: SerializeField] private GameObject m_losePanel;
    [field: SerializeField] private TextMeshProUGUI m_survivedTime;
    [field: SerializeField] private Button m_retryButton;

    public static PlayerComponents Player { get => m_player; }
    public static UnityEvent OnHPChange = new UnityEvent();

    private static PlayerComponents m_player;
    private static List<EnemyComponents> m_enemies = new List<EnemyComponents>();

    private float m_timer = 0f;

    public static bool GameOver = false;

    private void Awake()
    {
        OnHPChange.AddListener(ChangeHP);

        m_destroyAllEnemiesButton.onClick.AddListener(DestroyAllEnemies);
        m_retryButton.onClick.AddListener(ReloadLevel);
    }

    private void Start()
    {
        GameOver = false;
    }

    private void Update()
    {
        if (GameOver)
            return;

        m_timer += Time.deltaTime;

        m_timerText.text = $"{((int)m_timer / 60):D2}:{(int)Mathf.Round((int)m_timer % 60):D2}";
    }

    public void ChangeHP()
    {
        if (m_player == null)
            return;

        if (Player.PlayerStatus.HP <= 0)
            ShowLosePanel();

        m_hpText.text = $"HP: {Player.PlayerStatus.HP}";  
    }

    public static void SetPlayer(PlayerComponents player)
    {
        m_player = player;

        OnHPChange.Invoke();
    }

    public static void AddEnemy(EnemyComponents enemy)
    {
        m_enemies.Add(enemy);
    }

    public static void RemoveEnemy(EnemyComponents enemy)
    {
        if (m_enemies.Contains(enemy))
            m_enemies.Remove(enemy);
    }

    public void DestroyAllEnemies()
    {
        List<EnemyComponents> enemies = new List<EnemyComponents>();

        foreach (EnemyComponents enemy in m_enemies)
            enemies.Add(enemy);

        foreach (EnemyComponents enemy in enemies)
        {
            if (enemy == null)
                continue;

            RemoveEnemy(enemy);            

            enemy.DestroyEnemy();
        }
    }

    public void ShowLosePanel()
    {
        GameOver = true;

        m_losePanel.SetActive(true);

        m_survivedTime.text = $"{((int)m_timer / 60):D2}:{(int)Mathf.Round(m_timer % 60):D2}"; ;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
