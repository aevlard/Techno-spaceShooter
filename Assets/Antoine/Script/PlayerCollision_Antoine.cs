using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision_Antoine : CollisionHandlerBase_Antoine
{
    private PlayerShip_Antoine playerShip;
    private Player_Antoine player;

    private void Awake()
    {
        playerShip = GetComponent<PlayerShip_Antoine>();
        player = GetComponent<Player_Antoine>();
    }
    protected override void HandleCollision(Collider2D other)
    {

        if (other.TryGetComponent<Asteroid_Antoine>(out Asteroid_Antoine asteroid))
        {

            Debug.Log("Collision avec un astéroïde !");
            playerShip.ImpactEffect();
            player.TakeDamage(10);

        }
        else if (other.TryGetComponent<Ufo_Antoine>(out Ufo_Antoine ufo))
        {

            Debug.Log("Collision avec un OVNI !");

        }
        else if (other.TryGetComponent<Boss_Antoine>(out Boss_Antoine boss))
        {


            Debug.Log("Collision avec un boss !");

        }
    }
}