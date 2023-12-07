using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 20f;

    public float rightDashForce = 20f;

    public float leftDashForce = -20f;

    public float sprintSpeed = 20f;

    public int playerHealth = 5;

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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rigidBodyRef.AddForce(transform.right * rightDashForce, ForceMode.Impulse);
                //Debug.Log("Player dashed right");
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rigidBodyRef.AddForce(transform.right * leftDashForce, ForceMode.Impulse);
                //Debug.Log("Player dashed right");
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rigidBodyRef.AddForce(transform.forward * sprintSpeed, ForceMode.Acceleration);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpikePole")
        {
            playerHealth --;


            Debug.Log("Player is spiked up rn");
        }
    }


    private void Death()
    {
        //ego death
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2); 
            Debug.Log("This fella dead");
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
