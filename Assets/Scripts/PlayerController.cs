using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRb;

    [SerializeField]
    private string horizontalInputName;

    [SerializeField]
    private string verticalInputName;

    [SerializeField]
    private KeyCode shootKey;

    public bool isPaused;


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
        myRb = GetComponent<Rigidbody>();
        playerSkills = gameObject.GetComponent<PlayerSkills>();
        playerInventory = gameObject.GetComponentInChildren<WeaponInventory>();
    }
    void Update()
    {
       if(!isPaused) UpdatePlayerController();
    }
    private void FixedUpdate()
    {
        if(!isPaused) playerSkills.Movement(myRb, horizontalInputName, verticalInputName);
    }
    private void UpdatePlayerController()
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

    public void DesactivatePlayerInput()
    {
        isPaused = true;
    }
    public void ActivatePlayerInput()
    {
        isPaused = false;
    }


}
