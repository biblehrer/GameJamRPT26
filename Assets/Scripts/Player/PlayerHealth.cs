using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    [Header("Damage Flash")]
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f;


    public void Heal(int amount)
    {
        health += amount; 

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("Spieler geheilt! Leben: " + health);
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
        }

        Debug.Log("Player Hit ! Health Left  : " + health);

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