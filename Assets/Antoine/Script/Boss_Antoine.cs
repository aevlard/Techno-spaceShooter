using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Antoine : EnemyBase_Antoine
{

    [SerializeField] private int health = 100;

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void Parler()
    {
        Debug.Log("Je suis un Boss");
    }

    public override void TakeDamage(int damage)
    {
        Debug.Log("Je suis un astéroid");
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

}