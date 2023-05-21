using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public List<GameObject> players;

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
        CreatePlayer(Players.P1);
        CreatePlayer(Players.P2);
    }
    public void CreatePlayer(Players player)
    {
        Vector3 randomSpawn = SpawnManager.Instance.GetRandomSpawn();

        GameObject newPlayer = player == Players.P1 ? 
            Instantiate(player1Prefab,randomSpawn, Quaternion.identity): 
            Instantiate(player2Prefab,randomSpawn, Quaternion.identity);

        GameObject newCinemachineBrain = CameraManager.Instance.createCinemachineBrain();
        GameObject newVirtualCamera = CameraManager.Instance.createVirtualCamera();

        players.Add(newPlayer);

        PlayerController playerController = newPlayer.GetComponent<PlayerController>();
        CinemachineVirtualCamera newCameraCinemachine = newVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        newCameraCinemachine.Follow = playerController.gameObject.transform;


        Camera playerCamera = newCinemachineBrain.GetComponentInChildren<Camera>();
     

        playerController.GetComponentInChildren<HealthBar>().currentCamera = playerCamera;  
    }
   
}
