using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class feuerball : MonoBehaviour
{
    public int schnelligkeit = 2;
    public GameObject fireball;
    public Vector3 direction = new Vector3();
     [Header("Damage")]
    [SerializeField]
    private int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(fireball, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.position += transform.right * 1 * schnelligkeit * Time.deltaTime;

        
        
    }
    public void OverwriteDirection(Vector3 dir)
    {
        transform.right = dir;
        direction = transform.right;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if hit player
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Debug hit enemy");
            PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy bullet after hit
        }
    }
}
