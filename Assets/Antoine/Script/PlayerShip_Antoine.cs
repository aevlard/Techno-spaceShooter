using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_Antoine : InputListenerBase
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_boostSpeed;
    [SerializeField] private float m_accelerationTime;
    [SerializeField] private float m_decelerationTime;

    private bool isBoosting = false;
    private float currentSpeed = 0f;
    private float accelerationTimer = 0f;
    private float decelerationTimer = 0f;
    private Vector2 lastInputDirection = Vector2.zero;

    private float leftBoundary;
    private float rightBoundary;
    private float topBoundary;
    private float bottomBoundary;

    private bool hasTeleported = false;

    private PlayerShoot_Antoine playerShoot_Antoine;

    private void Awake()
    {
        leftBoundary = -Camera.main.orthographicSize * Camera.main.aspect;
        rightBoundary = Camera.main.orthographicSize * Camera.main.aspect;
        topBoundary = Camera.main.orthographicSize;
        bottomBoundary = -Camera.main.orthographicSize;

        playerShoot_Antoine = GetComponent<PlayerShoot_Antoine>();
    }

    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        // Si on appuye sur une touche de déplacement
        if (_inputAxes != Vector2.zero)
        {
            accelerationTimer += Time.deltaTime;
            decelerationTimer = 0f;
            currentSpeed = Mathf.Lerp(0, m_speed, accelerationTimer / m_accelerationTime); //acceleration progressive
            // ex si m_accel est de 2  apres 1 seconde vers une direction, on se situe a mi distance entre 0 et m_speed donc currentSpeed = 1

            lastInputDirection = _inputAxes.normalized; //on stocke la der direction pour la deceleration


            // Détection des limites de l'écran
            Vector3 newPosition = transform.position + new Vector3(_inputAxes.x, _inputAxes.y, 0) * currentSpeed * Time.deltaTime;
            CheckScreenBounds(newPosition);
        }
        // Si vous relâchez
        else
        {
            accelerationTimer = 0f;
            decelerationTimer += Time.deltaTime;
            currentSpeed = Mathf.Lerp(m_speed, 0, decelerationTimer / m_decelerationTime);
        }

        // Si vous activez le boost, utilisez la vitesse de boost
        if (isBoosting)
        {
            currentSpeed = m_boostSpeed;
        }

        // Calculer la vélocité en fonction de la vitesse actuelle
        Vector3 velocity = lastInputDirection * currentSpeed * Time.deltaTime; // lastInputDirection donne la direction du vecteur et currentSpeed sa "taille"


        // Appliquer la vélocité au vaisseau
        transform.position += velocity;

        // Calculer l'angle de rotation en fonction des axes d'entrée
        float rotationAngle = Mathf.Atan2(lastInputDirection.x, lastInputDirection.y) * Mathf.Rad2Deg; // Atan2 renvoie l'angle entre la composante Y et X du vecteur en radians, converti ensuite en degrés avec Mathf.Rad2Deg


        // Inverser l'angle pour faire face à la bonne direction
        rotationAngle *= -1f;

        // Créer une rotation en utilisant l'angle calculé (autour de l'axe Z)
        Quaternion newRotation = Quaternion.Euler(0, 0, rotationAngle); // La transform a besoin d'un quaternion pour faire la rota on lui passe donc notre angle

        // Appliquer la rotation au vaisseau
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, m_rotationSpeed * Time.deltaTime);
    }


    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        // Activer le boost lorsque la touche "Espace" est enfoncée
        if (_keyCode == KeyCode.Space)
        {
            isBoosting = true;
        }
    }

    public override void ProcessKeyCodeUp(KeyCode _keyCode)
    {
        // Désactiver le boost lorsque la touche "Espace" est relâchée
        if (_keyCode == KeyCode.Space)
        {
            isBoosting = false;
        }
    }



    private void CheckScreenBounds(Vector3 newPosition)
    {

        // Vérifiez si le vaisseau atteint les limites de l'écran
        if (newPosition.x < leftBoundary)
        {
            if (!hasTeleported)
            {
                newPosition.x = rightBoundary;
                hasTeleported = true;
            }
        }
        else if (newPosition.x > rightBoundary)
        {
            if (!hasTeleported)
            {
                newPosition.x = leftBoundary;
                hasTeleported = true;
            }
        }
        else if (newPosition.y > topBoundary)
        {
            if (!hasTeleported)
            {
                newPosition.y = bottomBoundary;
                hasTeleported = true;
            }
        }
        else if (newPosition.y < bottomBoundary)
        {
            if (!hasTeleported)
            {
                newPosition.y = topBoundary;
                hasTeleported = true;
            }
        }
        else
        {
            hasTeleported = false;
        }

        transform.position = newPosition;
    }



    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0)
        {
            playerShoot_Antoine.Shoot();
        }
    }

    public override void ProcessMouseButtonUp(int _button)
    {
        if (_button == 0)
        {
            playerShoot_Antoine.StopShooting();
        }
    }

    

}
