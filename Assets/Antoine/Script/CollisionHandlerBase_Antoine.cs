using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionHandlerBase_Antoine : MonoBehaviour
{
    protected abstract void HandleCollision(Collider2D other);

    protected void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }
}
