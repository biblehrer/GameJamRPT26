using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 20)]
    [SerializeField]
    private float speed = 10f;

    [Range(1, 10)]
    [SerializeField]
    private float lifeTime = 3f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        if (moveDirection != Vector2.zero)
        {
            rb.linearVelocity = moveDirection * speed;
        }
    }
    public void SetDirection(Vector2 dir)
    {
        //rotate bullet sprite
        moveDirection = dir.normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle); 
    }
}