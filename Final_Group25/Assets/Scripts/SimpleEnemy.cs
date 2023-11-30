using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    private Transform target;
    public float speed;

    public float health;
    
    //Attacking

     public float timeBetweenAttacks;

     bool alreadyAttacked;

     public float attackRange;



    /*
    private void AttackPlayer()
    {

     transform.LookAt(player);

     if (!alreadyAttacked)
        {
          alreadyAttacked = true;
          Invoke(nameof(ResetAttack), timeBetweenAttacks); 
         }


    private void ResetAttack()
    {
        alreadyAttacked = false; 
    }

    */

    


    // Start is called before the first frame update
    void Start()
    {
        health = 3; 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); 
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
