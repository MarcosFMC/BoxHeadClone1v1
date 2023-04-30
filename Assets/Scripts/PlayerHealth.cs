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

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        currentHealth = totalHealth;
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    public void TakeDamage(float dmg)
    {
        if (currentHealth > 0)
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
        Destroy(gameObject);
    }
}
