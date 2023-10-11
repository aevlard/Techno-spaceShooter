using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase_Antoine : MonoBehaviour
{
    public int health = 100;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public abstract void Die();

    public abstract void Parler();

}
