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
            // Spawn bullet
            GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);

            // Calculate direction to target
            Vector2 direction = (target.position - firingPoint.position).normalized;

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

}

