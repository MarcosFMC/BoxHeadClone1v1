using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float currentHealth = 0f;
    [SerializeField]
    private float totalHealth = 10f;
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float TotalHealth { get => totalHealth; }

    private HealthBar healthBar;

    private Animator myAnim;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        myAnim = GetComponent<Animator>();
        currentHealth = totalHealth;
    }
    public void TakeDamage(float dmg)
    {
        if (currentHealth >= 0)
        {
            currentHealth -= dmg;
            AudioManager.Instance.PlaySound(AudioNames.takeDamage);
            healthBar.UpdateHealthBar(totalHealth,currentHealth);
        }
        else
        {
            Death();
        }
    }
    public void Death()
    {
        
        if (myAnim.GetBool("isDead") == false)
        {
            AudioManager.Instance.PlaySound(AudioNames.death);
            myAnim.SetBool("isDead", true);
            StartCoroutine(ResetPlayer());
        }
    }
    private IEnumerator ResetPlayer()
    {
         yield return new WaitForSeconds(2f);
         currentHealth = totalHealth;
         myAnim.SetBool("isDead", false);
         healthBar.UpdateHealthBar(totalHealth, currentHealth);
         transform.position = SpawnManager.Instance.GetRandomSpawn();
    }
}
