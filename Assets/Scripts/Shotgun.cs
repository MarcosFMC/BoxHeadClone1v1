using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    Transform[] shootOriginArray;
    [SerializeField]
    private GameObject rayBulletPrefab;

  
    public override void Shoot() 
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shootOrigin in shootOriginArray)
            {
                Instantiate(rayBulletPrefab, shootOrigin.position, shootOrigin.rotation);
            }
            AudioManager.Instance.PlaySound(AudioNames.shotgunShoot);
        }  
    }
}

