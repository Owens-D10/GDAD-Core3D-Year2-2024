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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (vision.playerSpotted == true && vision.playerInAttackRange == false)
        {
            agent.SetDestination(destination.transform.position);
            GetComponent<Animator>().SetBool("IsMoving", true);
        }
        else if (vision.playerSpotted == false)
        {
            GetComponent<Animator>().SetBool("IsMoving", false);
        }
        else if (vision.playerInAttackRange == true)
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
        
        
    }
    
    void Damage()
    {
        player.TakeDamage(damage);
    }
    
    

    
}
