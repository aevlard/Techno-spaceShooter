using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer_Antoine : MonoBehaviour
{
    private PlayerShip_Antoine playerShip_Antoine;

    private void Awake()
    {
        GameObject playerShipObject = GameObject.Find("ShipTempate_Antoine");

        playerShip_Antoine = playerShipObject.GetComponent<PlayerShip_Antoine>();

    }

    private void Update()
    {
        if (transform.position.y > playerShip_Antoine.TopBoundary + 4)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < playerShip_Antoine.BottomBoundary - 4)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > playerShip_Antoine.RightBoundary + 4)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < playerShip_Antoine.LeftBoundary - 4)
        {
            Destroy(gameObject);
        }
    }
}
