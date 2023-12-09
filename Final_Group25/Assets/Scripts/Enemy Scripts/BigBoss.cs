using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigBoss : MonoBehaviour
{
    private Transform target;
    public float speed;

    private bool onWater;

    public float enemyHealth;

    public Rigidbody rigidBodyRef;
    public float jumpForce;

    //Attacking

    public float attackCooldown = 4f;
    public float attackTimer;

    public float attackRange = 3f;
    public float damage = 3f;

    public bool ghostAlive;

    private void AttackPlayer()
    {
        //playerHealth--;
        //ResetAttack(); 

    }

    private void ResetAttack()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttackPlayer();
        }

        if (other.gameObject.tag == "Water")
        {
            onWater = true;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rigidBodyRef = GetComponent<Rigidbody>();

        ghostAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        /*
        transform.LookAt(Vector3.gameObject.tag == "Player");
        */

        if (onWater == true)
        {
            Bounce();
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);

        SceneManager.LoadScene(2);
    }

    private void Bounce()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            Debug.Log("Player is touching the ground so jump");
            rigidBodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {

        }
    }
}
