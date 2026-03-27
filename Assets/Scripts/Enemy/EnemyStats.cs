using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    public int health = 20;
    public int maxhealth = 20;

    [Header("Damage Flash")]
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f;

    public float invincibilityDuration = 1.0f;
    private bool isInvincible = false;

    private EnemyDropRan dropScript;
    private LootMonster enemyLoot;

    private void Start()
    {
        dropScript = GetComponent<EnemyDropRan>();
        enemyLoot = GetComponent<LootMonster>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }

        if (dropScript != null)
        {
            StartCoroutine(BecomeInvincible());
        }
    }

    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        health -= amount;
        health = Mathf.Clamp(health, 0, maxhealth);

        // Flash red
        if (spriteRenderer != null)
        {
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(FlashRed());
            }
        }

        if (health <= 0)
        {
            enemyLoot.droploot();
            if (dropScript != null)
            {
                dropScript.whenDeath();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator FlashRed()
    {
        // Set to red
        spriteRenderer.color = Color.red;

        // Wait
        yield return new WaitForSeconds(flashDuration);

        // Back to original color
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}