using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    
    public static int damage = 1;
    EnemyHealth enemy;

    private void Start()
    {
        enemy = GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    

}
