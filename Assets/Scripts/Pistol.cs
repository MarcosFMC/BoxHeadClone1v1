using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField]
    private GameObject rayBulletPrefab;
    [SerializeField]
    private Transform shootOrigin;
    public override void Shoot()
    { 
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(rayBulletPrefab, shootOrigin.position, shootOrigin.rotation);
            AudioManager.Instance.PlaySound(AudioNames.pistolShoot);
        }
     
    }
}
