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

    public float LeftBoundary { get => leftBoundary; set => leftBoundary = value; }
    public float RightBoundary { get => rightBoundary; set => rightBoundary = value; }
    public float TopBoundary { get => topBoundary; set => topBoundary = value; }
    public float BottomBoundary { get => bottomBoundary; set => bottomBoundary = value; }

    private void Awake()
    {
        InitializeBoundary();
        playerShoot_Antoine = GetComponent<PlayerShoot_Antoine>();
    }

    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        // Si on appuye sur une touche de d�placement
        if (_inputAxes != Vector2.zero)
        {
            accelerationTimer += Time.deltaTime;
            decelerationTimer = 0f;
            currentSpeed = Mathf.Lerp(0, m_speed, accelerationTimer / m_accelerationTime); //acceleration progressive
            // ex si m_accel est de 2  apres 1 seconde vers une direction, on se situe a mi distance entre 0 et m_speed donc currentSpeed = 1

            lastInputDirection = _inputAxes.normalized; //on stocke la der direction pour la deceleration


            // D�tection des limites de l'�cran
            Vector3 newPosition = transform.position + new Vector3(_inputAxes.x, _inputAxes.y, 0) * currentSpeed * Time.deltaTime;
            CheckScreenBounds(newPosition);
        }
        // Si vous rel�chez
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

        // Calculer la v�locit� en fonction de la vitesse actuelle
        Vector3 velocity = lastInputDirection * currentSpeed * Time.deltaTime; // lastInputDirection donne la direction du vecteur et currentSpeed sa "taille"


        // Appliquer la v�locit� au vaisseau
        transform.position += velocity;

        // Calculer l'angle de rotation en fonction des axes d'entr�e
        float rotationAngle = Mathf.Atan2(lastInputDirection.x, lastInputDirection.y) * Mathf.Rad2Deg; // Atan2 renvoie l'angle entre la composante Y et X du vecteur en radians, converti ensuite en degr�s avec Mathf.Rad2Deg


        // Inverser l'angle pour faire face � la bonne direction
        rotationAngle *= -1f;

        // Cr�er une rotation en utilisant l'angle calcul� (autour de l'axe Z)
        Quaternion newRotation = Quaternion.Euler(0, 0, rotationAngle); // La transform a besoin d'un quaternion pour faire la rota on lui passe donc notre angle

        // Appliquer la rotation au vaisseau
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, m_rotationSpeed * Time.deltaTime);
    }


    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        // Activer le boost lorsque la touche "Espace" est enfonc�e
        if (_keyCode == KeyCode.Space)
        {
            isBoosting = true;
        }
    }

    public override void ProcessKeyCodeUp(KeyCode _keyCode)
    {
        // D�sactiver le boost lorsque la touche "Espace" est rel�ch�e
        if (_keyCode == KeyCode.Space)
        {
            isBoosting = false;
        }
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

    private void CheckScreenBounds(Vector3 newPosition)
    {

        // V�rifiez si le vaisseau atteint les limites de l'�cran
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

    public void InitializeBoundary()
    {

        leftBoundary = -Camera.main.orthographicSize * Camera.main.aspect;
        rightBoundary = Camera.main.orthographicSize * Camera.main.aspect;
        topBoundary = Camera.main.orthographicSize;
        bottomBoundary = -Camera.main.orthographicSize;

    }

    public void ImpactEffect()
    {
        accelerationTimer = 0f;
        decelerationTimer += Time.deltaTime;
        currentSpeed = 0f;

        // Calculez la direction du recul (dans cet exemple, on utilise l'oppos� de la direction actuelle du vaisseau).
        Vector3 impactDirection = -transform.up; // Utilisez la direction actuelle du vaisseau.

        // Appliquez un recul en fonction de la direction du recul.
        float impactForce = 100f; // Ajustez la force d'impact selon vos besoins.

        Vector3 newPosition = transform.position + impactDirection * impactForce * Time.fixedDeltaTime;
        transform.position = newPosition;

    }

}
