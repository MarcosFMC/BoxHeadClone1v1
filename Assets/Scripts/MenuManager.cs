using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuCanvas;

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
        if(state == GameState.Menu)
        {
            menuCanvas.SetActive(true);
        }
    }
}
