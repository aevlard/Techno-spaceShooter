using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase_Antoine : MonoBehaviour
{

    public abstract void TakeDamage(int damage);

    public abstract void Die();

    public abstract void Parler();

}
