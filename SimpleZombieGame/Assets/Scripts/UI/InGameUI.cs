using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [field: SerializeField] private GameInfoPanel _gameInfoPanel;
    [field: SerializeField] private LosePanel _losePanel;

    public void Initialize()
    {
        _losePanel.Initialize();
        _gameInfoPanel.Initialize();
    }

    public void GameUpdate()
    {
        _gameInfoPanel.GameUpdate();
    }

    public void UpdateHealth(float health)
    {
        _gameInfoPanel.UpdateHealth(health);
    }

    public void ShowLosePanel()
    {
        _losePanel.ShowPanel();
    }
}
