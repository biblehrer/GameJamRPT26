using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class RangedEnemy : MonoBehaviour
{
    [Header("Target")]
    private Transform target;


    [Header("Combat")]
    public GameObject bulletPrefab;
    public Transform firingPoint;
    public float distanceToShoot = 5f;
    public float fireRate = 1f;
    public int damageToPlayer = 1;

    private float fireTimer = 0f;

    [Header("Fair Shooting")]
    private Vector2 direction;

    public float aimDelay = 0.4f; 

    private void Start()
    {
        GetTarget();
    }

    private void Update()
    {
        if (target == null)
        {
            GetTarget();
            return;
        }

        float distanceToTarget = Vector2.Distance(target.position, transform.position);

        if (distanceToTarget <= distanceToShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        { 
            // Calculate direction to target
            Vector2 direction = (target.position - firingPoint.position).normalized;           
            StartCoroutine(DelayShoot(direction));

            fireTimer = fireRate;
        }
    }

    public IEnumerator DelayShoot(Vector2 direction)
    {
        yield return new WaitForSeconds(0.15f); 
        // Spawn bullet
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetDirection(direction);
        }
    }

    private void GetTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }
}