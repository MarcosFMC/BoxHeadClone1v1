using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Players
{
    P1,
    P2
}
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField]
    private GameObject player1Prefab;

    [SerializeField]
    private GameObject player2Prefab;

    [SerializeField]
    private List<GameObject> playersCanvases;

    [SerializeField]
    public List<GameObject> players;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void CreatePlayer(Players player)
    {
        Vector3 randomSpawn = SpawnManager.Instance.GetRandomSpawn();

        GameObject newPlayer = player == Players.P1 ?
            Instantiate(player1Prefab, randomSpawn, Quaternion.identity) :
            Instantiate(player2Prefab, randomSpawn, Quaternion.identity);

        GameObject newCinemachineBrain = CameraManager.Instance.createCinemachineBrain();
        GameObject newVirtualCamera = CameraManager.Instance.createVirtualCamera();

        players.Add(newPlayer);

        PlayerController playerController = newPlayer.GetComponent<PlayerController>();
        CinemachineVirtualCamera newCameraCinemachine = newVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        newCameraCinemachine.Follow = playerController.gameObject.transform;


        Camera playerCamera = newCinemachineBrain.GetComponentInChildren<Camera>();


        playerController.GetComponentInChildren<HealthBar>().currentCamera = playerCamera;

        GameObject playerCanvas = newPlayer.GetComponentInChildren<Canvas>().gameObject;
        playersCanvases.Add(playerCanvas);
    }
    private GameObject getPlayerByEnum(Players player)
    {
        if(player == Players.P1)
        {
            foreach (var p in players)
            {
                if (p.CompareTag("P1")) return p;
            }
        }
        else
        {
            foreach (var p in players)
            {
                if (p.CompareTag("P2")) return p;
            }

        }
        return null;
    }
    public IEnumerator RespawnPlayerByEnum(Players playerToReset)
    {
            yield return new WaitForSeconds(2f);
            GameObject player = getPlayerByEnum(playerToReset);

            PlayerHealth phScript = player.GetComponent<PlayerHealth>();
            Animator pAnim = player.GetComponent<Animator>();
            HealthBar pHealthBar = player.GetComponentInChildren<HealthBar>();

            phScript.CurrentHealth = phScript.TotalHealth;
            pAnim.SetBool("isDead", false);
            pHealthBar.UpdateHealthBar(phScript.TotalHealth, phScript.CurrentHealth);

            player.transform.position = SpawnManager.Instance.GetRandomSpawn();  
    }
    public void ResetStats()
    {
        foreach (var player in players)
        {
            PlayerHealth phScript = player.GetComponent<PlayerHealth>();
            Animator pAnim = player.GetComponent<Animator>();
            HealthBar pHealthBar = player.GetComponentInChildren<HealthBar>();
            LifeUI pLifeUI = player.GetComponentInChildren<LifeUI>();


           
            phScript.ResetLife();
            pAnim.SetBool("isDead", false);
            pHealthBar.UpdateHealthBar(phScript.TotalHealth, phScript.CurrentHealth);
            pLifeUI.UpdateLifeUI();

            player.transform.position = SpawnManager.Instance.GetRandomSpawn();
        }
    }
    public void Desactivate()
    {
        if(players != null)
        {
            foreach (var p in players)
            {
                p.GetComponent<PlayerController>().DesactivatePlayerInput();
            }
            foreach (var canvasGO in playersCanvases)
            {
                canvasGO.SetActive(false);
            }
        }
       
    }
    public void Activate()
    {
        if (players != null)
        {
            foreach (var p in players)
            {
                p.GetComponent<PlayerController>().ActivatePlayerInput();
            }
            foreach (var canvasGO in playersCanvases)
            {
                canvasGO.SetActive(true);
            }
        }
    }
}
