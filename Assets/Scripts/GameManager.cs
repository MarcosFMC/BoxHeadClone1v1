using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Menu,
    Gameplay,
    Winner,
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState) {

            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Gameplay:
                HandleGameplay();
                break;
            case GameState.Winner:
                HandleWinner();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleWinner()
    {
        PlayerManager.Instance.Desactivate();
    }

    private void HandleMenu()
    {
        PlayerManager.Instance.Desactivate();
    }

    private void HandleGameplay()
    {
        if (PlayerManager.Instance.players.Count == 0)
        {
            PlayerManager.Instance.CreatePlayer(Players.P1);
            PlayerManager.Instance.CreatePlayer(Players.P2);
        }
        PlayerManager.Instance.Activate();
        PlayerManager.Instance.ResetStats();
    }
}

