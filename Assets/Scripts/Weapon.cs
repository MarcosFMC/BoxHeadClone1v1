using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float fireRate;

    protected float nextFire;
    public abstract void Shoot();
}
