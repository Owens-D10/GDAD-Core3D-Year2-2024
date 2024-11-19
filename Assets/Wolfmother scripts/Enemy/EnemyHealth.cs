using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    public int currentHealth;
    public int maxHealth = 3;

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
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Animator>().SetBool("IsDead", true);
    }
}
