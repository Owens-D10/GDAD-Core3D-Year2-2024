using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyVision : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;
    public GameObject player;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool playerSpotted;
    public bool playerInAttackRange;
    public float attackRadius;
    [Range(0, 360)]
    public float attackAngle;



    void Update()
    {
        FieldOfViewCheck();
        AttackCheck();
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeCheck.Length != 0 )
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    playerSpotted = true;
                }
                
            }
            
             
        }
        else if(playerSpotted == true)
        {
            playerSpotted = false;
        }
    }

    private void AttackCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, attackRadius, targetMask);

        if (rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < attackAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    playerInAttackRange = true;
                }
                else
                {
                    playerInAttackRange = false;
                }
            }
            else
            {
                playerInAttackRange = false;
            }

        }
        else if (playerInAttackRange == true)
        {
            playerInAttackRange = false;
        }
    }
}





