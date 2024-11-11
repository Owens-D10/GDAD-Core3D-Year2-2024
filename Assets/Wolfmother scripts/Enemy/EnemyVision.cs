using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;
    public GameObject player;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool playerSpotted;



    void Update()
    {
        FieldOfViewCheck();
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
                else
                {
                    playerSpotted = false;
                }
            }
            else
            {
                playerSpotted = false;
            }
             
        }
        else if(playerSpotted == true)
        {
            playerSpotted = false;
        }
    }




}
