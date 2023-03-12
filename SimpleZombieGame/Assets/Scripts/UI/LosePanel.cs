using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [field: SerializeField] private GameObject _panel;
    [field: SerializeField] private TextMeshProUGUI _survivedTime;
    [field: SerializeField] private Button _retryButton;

    public void Initialize()
    {
        _retryButton.onClick.AddListener(Game.ReloadLevel);
    }
    public void ShowPanel()
    {
        _panel.SetActive(true);
        _survivedTime.text = $"{((int)Game.Timer / 60):D2}:{(int)Mathf.Round((int)Game.Timer % 60):D2}"; ;
    }
}
