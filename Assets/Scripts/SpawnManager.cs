using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField]
    public Transform[] spawns;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public Vector3 GetRandomSpawn()
    {
        int randomSpawn = Random.Range(0, spawns.Length);

        return spawns[randomSpawn].position;
    }
}
