using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement_Antoine : MonoBehaviour
{

    public float speed = 5.0f;
    private Vector3 direction;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
