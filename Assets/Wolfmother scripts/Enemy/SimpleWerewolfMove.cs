using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class SimpleWerewolfMove : MonoBehaviour
{
    public GameObject destination;
    NavMeshAgent agent;
    public EnemyVision vision;
    public GameObject werewolf;
    public float attackCooldown;
    public int damage = 1;
    public PlayerHealth player;
    public EnemyHealth health;
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (vision.playerSpotted == true && vision.playerInAttackRange == false && health.dead == false)
        {
            agent.SetDestination(destination.transform.position);
            animator.SetBool("IsMoving", true);
        }
        else if (vision.playerSpotted == false && health.dead == false)
        {
            agent.SetDestination(werewolf.transform.position);
            animator.SetBool("IsMoving", false);
        }
        else if (vision.playerInAttackRange == true && health.dead == false)
        {
            agent.SetDestination(werewolf.transform.position);
            animator.SetTrigger("Attack");
        }
        
        
    }
    
    void Damage()
    {
        if (vision.playerInAttackRange == true)
        {
            player.TakeDamage(damage);
        }
        animator.ResetTrigger("Attack");
    }
    
    

    
}
