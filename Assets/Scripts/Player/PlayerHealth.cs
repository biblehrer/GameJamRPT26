using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    
    public Dictionary<SwordType, int> swordCollection = new Dictionary<SwordType, int>()
    {
        { SwordType.WoodSword,0},
        { SwordType.BoneSword,0},
        { SwordType.IronSword,0},
        { SwordType.FireSword,0},
        { SwordType.DiamondSword,0},
        { SwordType.Netherrite,0},
        { SwordType.DestroyerSword,0},
    };

    public SwordType isUsingSword = SwordType.WoodSword;

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

        // Flash red
        if (spriteRenderer != null)
        {
            StartCoroutine(FlashRed());
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
public float damage = 10f;
}