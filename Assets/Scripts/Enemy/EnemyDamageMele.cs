// EnemyDamageMele.cs
using UnityEngine;

public class EnemyDamageMele : MonoBehaviour
{
    private GameObject player;

    public float attackDistance = 2f;
    public float damageAmount = 10f;
    public float attackCooldown = 2f;  // seconds between attacks
    private float lastAttackTime = -Mathf.Infinity;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("Distanz: " + distanceToPlayer + " | attackDistance: " + attackDistance);

        if (distanceToPlayer <= attackDistance)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (Time.time < lastAttackTime + attackCooldown) return;
        lastAttackTime = Time.time;
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)    
        {
            playerHealth.health -= (int)damageAmount;
        }
    }
}