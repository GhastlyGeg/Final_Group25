using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 20f;

    public float dashForce = 20f;
    
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

        if(Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                rigidBodyRef.AddForce(Vector3.right * dashForce, ForceMode.Impulse);
                //Debug.Log("Player dashed right");
            }
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
