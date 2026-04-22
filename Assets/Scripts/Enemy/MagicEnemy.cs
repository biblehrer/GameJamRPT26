using UnityEngine;
using System.Collections;

public class MagicEnemy : MonoBehaviour
{
    private GameObject player;
    public GameObject magicAreaObject;

    public float attackDistance = 4f; 
    public int damageAmount = 20;

    public float attackCooldown = 5f; 
    private float AttackTimer = 0f;

    public float tpCooldown = 10f;
    private float tpTimer = 0f;

    public float teleportRadius = 4f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        AttackTimer += Time.deltaTime;
        tpTimer += Time.deltaTime;

        if (AttackTimer >= attackCooldown)
        {
            Attack();
            AttackTimer = 0f;
        }

        if (tpTimer >= tpCooldown)
        {
            Teleport();
            tpTimer = 0f;
        }
    }

    private void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }
    
    private IEnumerator AttackCoroutine()
    {
        Vector3 spawnPosition = player.transform.position;
        GameObject warningArea = Instantiate(magicAreaObject, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(2f);

        float blastRadius = 3f;
        Collider2D[] hits = Physics2D.OverlapCircleAll(spawnPosition, blastRadius);
        foreach (Collider2D hit in hits)
        {
            PlayerStats playerHealth = hit.GetComponent<PlayerStats>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                break;
            }
        }
        Destroy(warningArea);
    }

    private void Teleport()
    {
        Vector2 randomPoint = GetRandomPointInRadius();
        transform.position = randomPoint;
    }

    Vector2 GetRandomPointInRadius()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(0f, teleportRadius);

        return (Vector2)player.transform.position + randomDirection * randomDistance;
    }
}
