using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleWerewolfMove : MonoBehaviour
{
    public GameObject destination;
    NavMeshAgent agent;
    public EnemyVision vision;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (vision.playerSpotted == true && vision.playerInRange == true)
        agent.SetDestination(destination.transform.position);
    }
}
