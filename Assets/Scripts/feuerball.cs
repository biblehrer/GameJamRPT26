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
    public float offset = 0;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z; 
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = (worldMousePos - transform.position).normalized; 

        
        Vector2 lookDir = (Vector2)worldMousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, angle + offset);
        Destroy(fireball, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.position += direction * 1 * schnelligkeit * Time.deltaTime;

        
        
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
