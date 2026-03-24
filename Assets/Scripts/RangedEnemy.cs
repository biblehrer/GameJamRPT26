using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Movement")]
    public float speed = 3f;
    public float rotateSpeed = 5f;
    public float distanceToStop = 3f;

    [Header("Combat")]
    public GameObject bulletPrefab;
    public Transform firingPoint;
    public float distanceToShoot = 5f;
    public float fireRate = 1f;
    public int damageToPlayer = 1;

    [Header("Health")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private float fireTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        GetTarget();
    }

    private void Update()
    {
        if (target == null)
        {
            GetTarget();
            return;
        }

        FaceTarget();

        float distanceToTarget = Vector2.Distance(target.position, transform.position);
        if (distanceToTarget <= distanceToShoot)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        float distanceToTarget = Vector2.Distance(target.position, transform.position);

        if (distanceToTarget >= distanceToStop)
        {
            // Move towards target (top-down)
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
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

    private void FaceTarget()
    {
        // Flip sprite based on target position
        if (target.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true; // Face left
        }
        else
        {
            spriteRenderer.flipX = false; // Face right
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // ===== INSERT PLAYER HEALTH STUFF HERE =====

            target = null;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(1);
        }
    }
}

