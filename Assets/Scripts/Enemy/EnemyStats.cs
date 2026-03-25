using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    public int health = 20;
    public int maxhealth = 20;

    [Header("Damage Flash")]
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxhealth);
        Debug.Log("Enemy Hit! Health Left: " + health);

        // Flash red
        if (spriteRenderer != null)
        {
            StartCoroutine(FlashRed());
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator FlashRed()
    {
        // Set to red
        spriteRenderer.color = Color.red;

        // Wait
        yield return new WaitForSeconds(flashDuration);

        // Back to original color
        spriteRenderer.color = Color.white;
    }
}

