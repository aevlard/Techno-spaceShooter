using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner_Antoine : MonoBehaviour
{

    [SerializeField] GameObject asteroidPrefab;
    private PlayerShip_Antoine playerShip_Antoine;

    private void Awake()
    {
        GameObject playerShipObject = GameObject.Find("ShipTempate_Antoine");

        playerShip_Antoine = playerShipObject.GetComponent<PlayerShip_Antoine>();

    }


    private void Start()
    {

        playerShip_Antoine.InitializeBoundary();

        for (int i = 0; i < 3; i++)
        {
            GenerateAsteroidFromTop();
            GenerateAsteroidFromBottom();
            GenerateAsteroidFromLeft();
            GenerateAsteroidFromRight();
        }


    }

    public float GenerateRandomPosition(float minPosition, float maxPosition, float step)
    {
        int numPossiblePositions = Mathf.FloorToInt((maxPosition - minPosition) / step) + 1;

        int randomIndex = Random.Range(0, numPossiblePositions);

        float randomPosition = minPosition + randomIndex * step;

        return randomPosition;
    }

    public void GenerateAsteroidFromTop()
    {

        float randomNumber = GenerateRandomPosition(playerShip_Antoine.LeftBoundary, playerShip_Antoine.RightBoundary, 0.5f);
        Vector3 randomPosition = new Vector3(randomNumber, playerShip_Antoine.TopBoundary + 3, 0f);
        GameObject asteroid = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);

        AsteroidMovement_Antoine asteroidMovement = asteroid.GetComponent<AsteroidMovement_Antoine>();
        asteroidMovement.SetDirection(Vector3.down);

    }

    public void GenerateAsteroidFromLeft()
    {
        float randomNumber = GenerateRandomPosition(playerShip_Antoine.BottomBoundary, playerShip_Antoine.TopBoundary, 0.5f);
        Vector3 randomPosition = new Vector3(playerShip_Antoine.LeftBoundary - 3, randomNumber, 0f);
        GameObject asteroid = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);

        AsteroidMovement_Antoine asteroidMovement = asteroid.GetComponent<AsteroidMovement_Antoine>();
        asteroidMovement.SetDirection(Vector3.right);
    }

    public void GenerateAsteroidFromRight()
    {
        float randomNumber = GenerateRandomPosition(playerShip_Antoine.BottomBoundary, playerShip_Antoine.TopBoundary, 0.5f);
        Vector3 randomPosition = new Vector3(playerShip_Antoine.RightBoundary + 3, randomNumber, 0f);
        GameObject asteroid = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);

        AsteroidMovement_Antoine asteroidMovement = asteroid.GetComponent<AsteroidMovement_Antoine>();
        asteroidMovement.SetDirection(Vector3.left);
    }

    public void GenerateAsteroidFromBottom()
    {
        float randomNumber = GenerateRandomPosition(playerShip_Antoine.LeftBoundary, playerShip_Antoine.RightBoundary, 0.5f);
        Vector3 randomPosition = new Vector3(randomNumber, playerShip_Antoine.BottomBoundary - 3, 0f);
        GameObject asteroid = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);

        AsteroidMovement_Antoine asteroidMovement = asteroid.GetComponent<AsteroidMovement_Antoine>();
        asteroidMovement.SetDirection(Vector3.up);
    }


}
