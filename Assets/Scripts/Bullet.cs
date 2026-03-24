using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [Range(1, 20)]
    [SerializeField]
    private float speed = 10f;

    [Range(1, 10)]
    [SerializeField]
    private float lifeTime = 3f;

    [Header("Damage")]
    [SerializeField]
    private int damage = 10;


    private Rigidbody2D rb;

    public void SetDirection(Vector2 dir)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        Destroy(gameObject, lifeTime);

        Vector2 moveDirection = dir.normalized;
        //rotate bullet sprite

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rb.linearVelocity = moveDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if hit player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy bullet after hit
        }
    }
}