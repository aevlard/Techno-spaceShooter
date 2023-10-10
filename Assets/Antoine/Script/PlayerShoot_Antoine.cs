using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot_Antoine : MonoBehaviour
{


    public GameObject projectilePrefab;
    public Transform firePoint;

    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    private bool canShoot = true;

    public void Shoot()
    {
        if (canShoot)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(projectile, 2f);

            canShoot = false;

            StartCoroutine(ResetFireRate());

        }
    }

    IEnumerator ResetFireRate()
    {
        yield return new WaitForSeconds(1f / fireRate);
        canShoot = true;
    }

    public void ShootOnCursor()
    {
        if (Time.time >= nextFireTime)
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 shootDirection = (mousePosition - transform.position).normalized;

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shootDirection * projectileSpeed;
            }

            Destroy(projectile, 2f);

            nextFireTime = Time.time + 1f / fireRate;
        }
    }


    public void StopShooting()
    {
        nextFireTime = 0f;
    }



}
