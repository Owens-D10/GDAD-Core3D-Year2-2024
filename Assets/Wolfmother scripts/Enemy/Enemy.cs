using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour, IDamagable
{
    
    
    
    [Space(10)]  
    [Header("Enemy State")]  
    private IEnemyState currentState;     // Reference to the current state  
    public Transform target;              // Reference to the player or target  

    
    [Space(10)]  
    [Header("Enemy FX")]  
    public GameObject dieEffectPrefab; // Reference to the die effect prefab  

    // From previous health script
    public int currentHealth; 
    public int maxHealth = 3;
    public bool dead;
    public Animator animator;
    public Rigidbody rb;
    public BoxCollider box;
    public EnemyVision vision;
    public AudioSource deathHowl;
    public ParticleSystem bloodEffect;

    public GameObject destination;
    public NavMeshAgent agent;
    public GameObject werewolf;
    public float attackCooldown = 1.5f;
    public Player player;
    public bool canAttack;
    public int damage = 1;
    public AudioSource footstep;
    
    private void Start()
    {
        // Start with the Idle state
        SetState(new EnemyState_Idle());
        
        // Find the player in the scene
        currentHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();

        canAttack = true;
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
        if (currentHealth <= 0)
        {
            Die();
            deathHowl.Play();
        }
    }

    
    private void Update()
    {
        // Delegate behaviour to the current state
        currentState?.Update(this);

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
        vision.enabled = false;



    }

    void FinishDeath()
    {
        animator.ResetTrigger("Dying");
    }

    void ResetTakeDamage()
    {
        GetComponent<Animator>().SetTrigger("TakeDamage");

    }

    public void SetState(IEnemyState newState)
    {
        // Exit the current state and enter the new state
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }
    
    public string GetCurrentStateName()
    {
        if (currentState != null)
        {
            string stateName = currentState.GetType().Name;
            return stateName.Replace("Enemy", "");
        }
        return "No State";
    }

    public IEnumerator AttackCooldown() // Cooldown for werewolf attacking animation
    {
        canAttack = false;

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }

    void Damage() // Method called in werewolf attack animation to damage the player
    {
        if (vision.playerInAttackRange == true)
        {
            player.TakeDamage(damage);
        }
    }

    void RepeatAttack() // Method called in attack animation to repeat attack if player is still in attack range
    {
        StartCoroutine(AttackCooldown());
    }

    void FootSteps()
    {
        footstep.pitch = UnityEngine.Random.Range(-0.5f, 0f);
        footstep.Play();
    }

    void IsDead()
    {
        animator.SetBool("IsDead", true);
    }
}
