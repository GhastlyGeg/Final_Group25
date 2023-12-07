using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//12/5/2023
//Enemy movement and attacking

public class SimpleEnemy : MonoBehaviour
{

    private Transform target;
    public float speed;



    public float enemyHealth;
    
    //Attacking

     public float attackCooldown = 4f;
    public float attackTimer; 

     public float attackRange = 3f;
    public float damage = 3f;



  
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
    }
    


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 3; 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        /*
        transform.LookAt(Vector3.gameObject.tag == "Player");
        */
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
