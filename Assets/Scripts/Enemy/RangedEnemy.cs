using UnityEngine;

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
    private bool hasLockedAim = false;

    public float aimDelay = 0.4f; 
    private float aimTimer = 0f;

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
            DelayedShooting();
        }
        else
        {
            // Reset if player leaves range
            hasLockedAim = false;
            aimTimer = 0f;
        }
    }
    private void Shoot()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            //spawn bullet
            GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);

            Bullet bullet = bulletObj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetDirection(direction);
            }

            fireTimer = fireRate;
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

    private void DelayedShooting()
    {
        // lock the direction on aim
        if (!hasLockedAim)
        {
            direction = (target.position - firingPoint.position).normalized;
            hasLockedAim = true;
            aimTimer = aimDelay;
        }

        // wait before shooting
        aimTimer -= Time.deltaTime;

        if (aimTimer <= 0f)
        {
            Shoot();
            hasLockedAim = false; // Reset
        }
    }
}

