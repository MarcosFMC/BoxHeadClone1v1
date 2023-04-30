using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    private float playerSpeed = 5f;
    public void Movement(Rigidbody myRb,string horizontal,string vertical)
    {
        float moveH = Input.GetAxis(horizontal);
        float moveV = Input.GetAxis(vertical);
        Vector3 movement = new Vector3(moveH, 0, moveV);
        myRb.MovePosition(transform.position + movement * playerSpeed * Time.deltaTime);
    }
}
