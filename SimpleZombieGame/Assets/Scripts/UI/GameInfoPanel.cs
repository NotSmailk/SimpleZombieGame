using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoPanel : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI _timerText;
    [field: SerializeField] private TextMeshProUGUI _healthText;
    [field: SerializeField] private Button _destroyAllEnemiesButton;

    public void Initialize()
    {
        _destroyAllEnemiesButton.onClick.AddListener(Game.DestroyAllEnemies);
    }

    public void GameUpdate()
    {
        _timerText.text = $"{((int)Game.Timer / 60):D2}:{(int)Mathf.Round((int)Game.Timer % 60):D2}";
    }

    public void UpdateHealth(float health)
    {
        _healthText.text = $"Health: {health}";
    }
}
