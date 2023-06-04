using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public int totalLifes = 1;
    [SerializeField]
    public int currentLife = 0;
    [SerializeField]
    private float currentHealth = 0f;
    [SerializeField]
    private float totalHealth = 10f;
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float TotalHealth { get => totalHealth; }

    private LifeUI lifeUI;

    private Animator myAnim;

    private HealthBar healthBar;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        lifeUI = GetComponentInChildren<LifeUI>();
        healthBar = GetComponentInChildren<HealthBar>();
        currentHealth = totalHealth;
        currentLife = totalLifes;
        
    }
    public void TakeDamage(float dmg)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmg;
            AudioManager.Instance.PlaySound(AudioNames.takeDamage);
            healthBar.UpdateHealthBar(totalHealth,currentHealth);
            if(currentHealth <= 0) Death();
        }
    }
    public void Death()
    {
        if (myAnim.GetBool("isDead") == false)
        {
            currentLife--;
            lifeUI.UpdateLifeUI();
            AudioManager.Instance.PlaySound(AudioNames.death);
            myAnim.SetBool("isDead", true);
            if (currentLife > 0)
            {

                if (gameObject.CompareTag("P1"))
                {
                    PlayerManager.Instance.RespawnPlayerByEnum(Players.P1);
                }
                else
                {
                    PlayerManager.Instance.RespawnPlayerByEnum(Players.P2);
                }

            }
            else
            {
                GameManager.Instance.UpdateGameState(GameState.Winner);


                if (gameObject.CompareTag("P1"))
                {
                    VictoryManager.Instance.setWinnerText(Players.P2);
                }
                else
                {
                    VictoryManager.Instance.setWinnerText(Players.P1);
                }
            }
        }
    }
    public void ResetLife()
    {
        currentHealth = totalHealth;
        currentLife = totalLifes;
    }
  

}
