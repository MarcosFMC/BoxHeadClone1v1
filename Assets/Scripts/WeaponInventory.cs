using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    [SerializeField]
    private GameObject[] guns;

    [SerializeField]
    public GameObject currentWeapon;

    [SerializeField]
    public List<GameObject> inventory = new List<GameObject>();

    private int currentWeaponIndex = 0;


    private void Start()
    {
        setWeapons();
    }

    public void switchWeapon()
    {
        if (currentWeaponIndex < guns.Length - 1)
        {
            inventory[currentWeaponIndex].SetActive(false);
            currentWeaponIndex++;
            currentWeapon = inventory[currentWeaponIndex];
            inventory[currentWeaponIndex].SetActive(true);
        }
        else
        {
            inventory[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 0;
            currentWeapon = inventory[currentWeaponIndex];
            inventory[currentWeaponIndex].SetActive(true);
        }
    }

    private void setWeapons()
    {
        foreach (var currentGun in guns)
        {
            GameObject instantiateGO = Instantiate(currentGun, gameObject.transform);
            inventory.Add(instantiateGO);
            instantiateGO.SetActive(false);
        }

        inventory[currentWeaponIndex].SetActive(true);
        currentWeapon = inventory[currentWeaponIndex];
    }
}
