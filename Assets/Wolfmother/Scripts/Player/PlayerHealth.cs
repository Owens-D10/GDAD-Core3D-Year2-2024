using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamagable
{

    public int currentHealth;
    public int maxHealth = 7;
    public AudioSource heavyBreathing;
    public ParticleSystem bloodEffect;
    public PlayerHealth health;
    public TankControls controls;
    public WeaponMechanics weapon;
    public BoxCollider box;
    public Rigidbody rb;
    public AudioSource hurt;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 3)
        {
            heavyBreathing.enabled = true;
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
        bloodEffect.Play();
        hurt.Play();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        GetComponent<Animator>().SetBool("IsDead", true);
        health.enabled = false;
        controls.enabled = false;
        weapon.enabled = false;
        box.enabled = false;
        rb.useGravity = false;
        heavyBreathing.enabled = false;
        
    }

    void ResetTakeDamage()
    {
        GetComponent<Animator>().ResetTrigger("TakeDamage");
    }

    void ShowDeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Game");
    }

   
    public void QuitButton()
    {
        SceneManager.LoadScene("Title");
    }

}
