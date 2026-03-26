using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour
{
    public int type; // 0 = Heal, 1 = Damage Boost, 2 = Speed Boost
    public int healAmount = 25;

    [Header("Sprites für Potion")]
    public Sprite healSprite;
    public Sprite damageSprite;
    public Sprite speedSprite;

    [Header("Boost Werte")]
    public float boostMultiplier = 2f;
    public float boostDuration = 5f;

    private bool playerInRange = false;

    private PlayerStats playerHealth;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        type = Random.Range(0, 3);

        SetPotionLook();

        Debug.Log("Potion Type: " + type);
    }

    void Update()
    {
        if (playerInRange && Input.GetButton("ActionButten"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            playerHealth = other.GetComponent<PlayerStats>();
            playerMovement = other.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            playerHealth = null;
            playerMovement = null;
        }
    }

    void ApplyEffect()
    {
        switch (type)
        {
            case 0: // Heal
                playerHealth?.Heal(healAmount);
                break;

            case 1: //  Damage Boost
                StartCoroutine(DoDamageBoost(boostMultiplier, boostDuration));
                break;

            case 2: //  Speed Boost
                playerMovement?.SpeedBoost(boostMultiplier, boostDuration);
                break;
        }
    }

    IEnumerator DoDamageBoost(float multiplier, float duration)
    {
        AttackHitBox.damageMultiplier *= multiplier;
        yield return new WaitForSeconds(duration);
        AttackHitBox.damageMultiplier /= multiplier;
    }



    void SetPotionLook()
    {
        if (spriteRenderer == null) return;

        switch (type)
        {
            case 0:
                spriteRenderer.sprite = healSprite;
                break;

            case 1:
                spriteRenderer.sprite = damageSprite;
                break;

            case 2:
                spriteRenderer.sprite = speedSprite;
                break;
        }
    }

}