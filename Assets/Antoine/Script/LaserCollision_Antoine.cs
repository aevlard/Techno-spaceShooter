using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision_Antoine : CollisionHandlerBase_Antoine
{
    protected override void HandleCollision(Collider2D other)
    {
        if (other.TryGetComponent<Asteroid_Antoine>(out Asteroid_Antoine asteroid))
        {
            asteroid.TakeDamage(10);
            DestroySelf();
        }
        else if (other.TryGetComponent<Ufo_Antoine>(out Ufo_Antoine ufo))
        {
            ufo.TakeDamage(10);
            DestroySelf();
        }
        else if (other.TryGetComponent<Boss_Antoine>(out Boss_Antoine boss))
        {
            boss.TakeDamage(10);
            DestroySelf();
        }

    }
}
