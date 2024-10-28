using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    public float life = 0.5f;
    public static int damage = 1;
    private void Awake()
    {
        Destroy(gameObject, life);
    }


}
