using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject menuCamera;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
    
    public void playButton()
    {
        GameManager.Instance.UpdateGameState(GameState.Gameplay);
    }
    private void GameManager_OnGameStateChanged(GameState state)
    {
        menuUI.SetActive(state == GameState.Menu);
        menuCamera.SetActive(state == GameState.Menu);
    }
}
