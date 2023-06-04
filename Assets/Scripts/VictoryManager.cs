using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{

    public static VictoryManager Instance;

    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private TextMeshProUGUI winnerText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
    private void GameManager_OnGameStateChanged(GameState state)
    {
        menuUI.SetActive(state == GameState.Winner);
    }

    public void setWinnerText(Players winner)
    {
        winnerText.text = winner == Players.P1 ? "Victoria P1" : "Victoria P2";
    }

    public void RestartButton()
    {
        GameManager.Instance.UpdateGameState(GameState.Gameplay);
    }

    public void MenuButton()
    {
        GameManager.Instance.UpdateGameState(GameState.Menu);
    }
}
