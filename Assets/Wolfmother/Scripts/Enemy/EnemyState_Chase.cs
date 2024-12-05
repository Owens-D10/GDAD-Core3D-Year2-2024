using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState_Chase : IEnemyState
{

    
    public void Enter(Enemy enemy)
    {
        Debug.Log("Entering Chase State");
        enemy.agent.SetDestination(enemy.destination.transform.position);
        enemy.animator.SetBool("IsMoving", true);
    }

    public void Update(Enemy enemy)
    {

        // Transition back to Idle if player is out of range
        if (enemy.vision.playerSpotted == false && enemy.dead == false)
        {
            enemy.SetState(new EnemyState_Idle());
        }
        else if (enemy.vision.playerInAttackRange == true && enemy.dead == false && enemy.canAttack == false)
        {
            enemy.SetState(new EnemyState_Idle());
        }
        if (enemy.vision.playerInAttackRange == true && enemy.dead == false && enemy.canAttack == true)
        {
            enemy.SetState(new EnemyState_Attack());
        }
    }

    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Chase State");
        
    }
}