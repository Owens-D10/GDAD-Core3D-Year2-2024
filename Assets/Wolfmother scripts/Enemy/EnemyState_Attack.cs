using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState_Attack : IEnemyState
{
    
    public int damage = 1;
    

    public void Enter(Enemy enemy)
    {
        Debug.Log("Entering Patrol Attack");
        enemy.agent.SetDestination(enemy.werewolf.transform.position);
        enemy.animator.SetTrigger("Attack");
        enemy.canAttack = false;
        
    }

    public void Update(Enemy enemy)
    {
        // Check for player in range to switch to Chase
        if(enemy.vision.playerSpotted == true && enemy.vision.playerInAttackRange == false && enemy.dead == false)
        {
            enemy.SetState(new EnemyState_Chase());
        }
        
        if(enemy.vision.playerSpotted == false || enemy.vision.playerInAttackRange == true && enemy.dead == false)
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
        Debug.Log("Exiting Patrol State");
    }

    


}