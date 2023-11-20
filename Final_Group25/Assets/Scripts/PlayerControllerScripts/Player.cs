using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 20f;
    
    private Rigidbody rigidBodyRef;

    void Start()
    {
        rigidBodyRef = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleJump();
        }
    }

    private void HandleJump()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            //Debug.Log("Player is touching the ground so jump");
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            //Debug.Log("Player is not touching the ground so they can't jump");
        }
    }
}  // end of Player Script
