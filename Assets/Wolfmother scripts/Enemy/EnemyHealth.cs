using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public int health = 5;
    public Rigidbody rb;
    public BoxCollider collide;
    public NavMeshAgent agent;
    public EnemyVision enemyVision;
    public SimpleWerewolfMove werewolfMove;



    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            GetComponent<Animator>().Play("werewolf_death");
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && health > 0)
        {
            health -= BulletProjectile.damage;
        }
    }
    
    public void Death()
    {
        rb.useGravity = false;
        collide.enabled = false;
        agent.enabled = false;
        enemyVision.enabled = false;
        werewolfMove.enabled = false;

    }

}
