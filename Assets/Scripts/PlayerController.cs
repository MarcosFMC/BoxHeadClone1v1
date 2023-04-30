using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRb;

    [SerializeField]
    private string horizontalInputName;

    [SerializeField]
    private string verticalInputName;

    [SerializeField]
    private KeyCode shootKey;


    [SerializeField]
    private KeyCode up;
    [SerializeField]
    private KeyCode down;
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode right;

    [SerializeField]
    private KeyCode switchWeaponKey;

    private PlayerSkills playerSkills;

    private WeaponInventory playerInventory;

    private void Awake()
    {
        playerSkills = gameObject.GetComponent<PlayerSkills>();
        playerInventory = gameObject.GetComponentInChildren<WeaponInventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            playerInventory.currentWeapon.GetComponent<Weapon>().Shoot();
        }

        if (Input.GetKeyDown(switchWeaponKey))
        {
            playerInventory.switchWeapon();
        }

        //BASIC ROTATIONS
        if (Input.GetKey(up))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKey(down))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKey(left))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKey(right))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        //DIAGONAL ROTATIONS
        if (Input.GetKey(up) && Input.GetKey(left))
        {
            transform.rotation = Quaternion.Euler(0f, -45f, 0f);
        }
        if (Input.GetKey(up) && Input.GetKey(right))
        {
            transform.rotation = Quaternion.Euler(0f, 45f, 0f);
        }
        if (Input.GetKey(down) && Input.GetKey(left))
        {
            transform.rotation = Quaternion.Euler(0f, -145f, 0f);
        }
        if (Input.GetKey(down) && Input.GetKey(right))
        {
            transform.rotation = Quaternion.Euler(0f, 145f, 0f);
        }
    }
    private void FixedUpdate()
    {
        playerSkills.Movement(myRb,horizontalInputName,verticalInputName);
    }


}