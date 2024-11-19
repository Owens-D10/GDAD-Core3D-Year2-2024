using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage 
{
    void Damage(int damageAmount);

    void Death();

    int MaxHealth { get; set;  }

    int CurrentHealth {  get; set; }

}
