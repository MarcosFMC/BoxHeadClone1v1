using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private RectTransform rectTransform;

    [SerializeField]
    private Camera currentCamera;

    [SerializeField]
    private Image fillHealthBar;

    [SerializeField]
    private Vector3 healthBarOffset;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        rectTransform.position = currentCamera.WorldToScreenPoint(playerTransform.position + healthBarOffset);
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        fillHealthBar.fillAmount = currentHealth / maxHealth ;
    }

   
}
