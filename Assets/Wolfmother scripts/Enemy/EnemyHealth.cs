using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    public int currentHealth;
    public int maxHealth = 3;
    public bool dead;
    public Animator animator;
    public NavMeshAgent agent;
    public Rigidbody rb;
    public BoxCollider box;
    public SimpleWerewolfMove SimpleWerewolfMove;
    public EnemyVision EnemyVision;
    public AudioSource deathHowl;
    

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void ShowHitEffect()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GetComponent<Animator>().SetTrigger("TakeDamage");
        if (currentHealth <= 0)
        {
            Die();
            deathHowl.Play();
        }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Dying");
        dead = true;
        rb.useGravity = false;
        box.enabled = false;
        agent.enabled = false;
        SimpleWerewolfMove.enabled = false;
        EnemyVision.enabled = false;
        

        
    }
    void FinishDeath()
    {
        animator.ResetTrigger("Dying");
    }

    void ResetTakeDamage()
    {
        GetComponent<Animator>().SetTrigger("TakeDamage");

    }
}
