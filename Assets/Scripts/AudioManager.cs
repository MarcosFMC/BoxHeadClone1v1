using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AudioNames
{
    pistolShoot = 0,
    shotgunShoot = 1,
    takeDamage = 2,
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] audioClip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void PlaySound(AudioNames audioIndex)
    {
        audioSource.PlayOneShot(audioClip[(int)audioIndex]);
    }



}
