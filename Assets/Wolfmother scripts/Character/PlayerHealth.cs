using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{

    public int currentHealth;
    public int maxHealth = 7;
    public AudioSource heavyBreathing;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 3)
        {
            heavyBreathing.Play();
        }
        else if (currentHealth > 3 || currentHealth <= 0) 
        {
            heavyBreathing.Stop();
        }
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
        }
    }

    void Die()
    {
        
        GetComponent<Animator>().SetBool("IsDead", true);
    }

    void ResetTakeDamage()
    {
        GetComponent<Animator>().ResetTrigger("TakeDamage");
    }
}
