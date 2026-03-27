using UnityEngine;
public class EnemyDamageMele : MonoBehaviour
{
    private GameObject player;

    public float attackDistance = 0.5f; 
    public int damageAmount = 10;

    public float attackCooldown = 2f; 
    private float cooldownTimer = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Timer hochzählen
        cooldownTimer += Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); //distanz zum spieler berechnen

        // wenn spieler distanz und timer (zwischen attacken) passen dann angriff
        if (distanceToPlayer <= attackDistance && cooldownTimer >= attackCooldown)
        {
            Attack();
            cooldownTimer = 0f; // timer resetted
        }
    }

    void Attack()
    {
        PlayerStats playerHealth = player.GetComponent<PlayerStats>();
        playerHealth.TakeDamage(damageAmount);
    }
}