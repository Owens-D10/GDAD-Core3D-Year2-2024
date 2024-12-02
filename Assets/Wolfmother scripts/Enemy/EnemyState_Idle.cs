using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState_Idle : IEnemyState
{


    

    public void Enter(Enemy enemy)
    {
        Debug.Log("Entering Idle State");
        enemy.agent.SetDestination(enemy.werewolf.transform.position);
        enemy.animator.SetBool("IsMoving", false);
    }

    public void Update(Enemy enemy)
    {
        if(enemy.vision.playerSpotted == true && enemy.vision.playerInAttackRange == false && enemy.dead == false)
        {
            enemy.SetState(new EnemyState_Chase());
        }

        if(enemy.vision.playerInAttackRange == true && enemy.dead == false && enemy.canAttack == true)
        {
            enemy.SetState(new EnemyState_Attack());
        }
        
    }

    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Idle State");
    }
}