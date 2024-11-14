using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleWerewolfMove : MonoBehaviour
{
    public GameObject destination;
    NavMeshAgent agent;
    public EnemyVision vision;
    public GameObject werewolf;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (vision.playerSpotted == true && vision.playerInAttackRange == false)
        {
            agent.SetDestination(destination.transform.position);
            werewolf.GetComponent<Animator>().Play("werewolf_walking");
        }
        else if (vision.playerSpotted == false)
        {
            werewolf.GetComponent<Animator>().Play("werewolf_idle");
        }
        else if (vision.playerInAttackRange == true)
        {
            GetComponent<Animator>().Play("werewolf_attack");
        }
        
    }
    

    
}
