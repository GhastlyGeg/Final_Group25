using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI; 

/*
public class Enemy : MonoBehaviour
{ 
    int enemySpeed;
    float enemyPosition;
    float playerPosition; 
   
    //Bouta full copy all this nonsense and we can remove what isn't necessary later gator

    public NavMeshAgent; 

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health; 

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        //Check for sight and Attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); 
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }


    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false; 
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true; 
    }
    private void ChasePlayer()
    {
        Vector3 chasePlayer = 

        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); 
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false; 
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
*/