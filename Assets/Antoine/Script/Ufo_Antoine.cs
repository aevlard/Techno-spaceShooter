using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo_Antoine : EnemyBase_Antoine
{
    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void Parler()
    {
        Debug.Log("Je suis un UFO");
    }
}