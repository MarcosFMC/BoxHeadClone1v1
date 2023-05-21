using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField]
    private GameObject cinemachineBrain;

    [SerializeField]
    private GameObject cinemachineBrainP2;

    [SerializeField]
    private GameObject cinemachineVirtualCamera;

    [SerializeField]
    private GameObject cinemachineVirtualCameraP2;


    [SerializeField]
    private List<GameObject> cameras;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public GameObject createCinemachineBrain()
    {

        if(PlayerManager.Instance.players.Count == 1)
        {
            GameObject newCinemachineBrain = Instantiate(cinemachineBrainP2, gameObject.transform);
            cameras.Add(newCinemachineBrain);
            return newCinemachineBrain;
        }
        else
        {
            GameObject newCinemachineBrain = Instantiate(cinemachineBrain, gameObject.transform);
            cameras.Add(newCinemachineBrain);
            return newCinemachineBrain;
        } 
     
    }
    public GameObject createVirtualCamera()
    {
        if (PlayerManager.Instance.players.Count == 1)
        {
            GameObject newVirtualCamera = Instantiate(cinemachineVirtualCameraP2, gameObject.transform);
            return newVirtualCamera;
        }
        else
        {
            GameObject newVirtualCamera = Instantiate(cinemachineVirtualCamera, gameObject.transform);
            return newVirtualCamera;
        }
    }


}
