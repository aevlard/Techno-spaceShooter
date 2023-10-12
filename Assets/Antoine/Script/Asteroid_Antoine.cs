using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Antoine : EnemyBase_Antoine
{

    [SerializeField] private int health = 20;

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void Parler()
    {
        Debug.Log("Je suis un astéroid");
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
