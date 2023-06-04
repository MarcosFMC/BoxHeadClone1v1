using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{

    [SerializeField] 
    private PlayerHealth playerHealthScript;

    private TextMeshProUGUI lifeText;

    private void Awake()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        UpdateLifeUI();
    }

    public void UpdateLifeUI()
    {
        lifeText.text = "Lives: " + playerHealthScript.currentLife;
    }
}
