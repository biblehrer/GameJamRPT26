using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
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

    public void Awake()
    {
        AttackHitBox.damageMultiplier = 1;
    }

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
        AutoSelectStrongestSword();
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

    void AutoSelectStrongestSword()
    {
        int swordCount = System.Enum.GetValues(typeof(SwordType)).Length;

        for (int i = swordCount - 1; i >= 0; i--)
        {
            SwordType sword = (SwordType)i;

            if (swordCollection.TryGetValue(sword, out int amount) && amount > 0)
            {
                isUsingSword = sword;
                return;
            }
        }

        isUsingSword = SwordType.WoodSword;
    }

    public void DamageBoost(float multiplier, float duration)
    {
        StartCoroutine(DoDamageBoost(multiplier, duration));
    }

    IEnumerator DoDamageBoost(float multiplier, float duration)
    {
        AttackHitBox.damageMultiplier *= multiplier;
        yield return new WaitForSeconds(duration);
        AttackHitBox.damageMultiplier /= multiplier;
    }
}