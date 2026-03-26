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

    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private AttackHitBox attackHitBox; 
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
            if (playerHealth != null)
            {
                ApplyEffect();
                Debug.Log("Potion benutzt!");

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            playerHealth = other.GetComponent<PlayerHealth>();
            playerMovement = other.GetComponent<PlayerMovement>();
            attackHitBox = other.GetComponent<AttackHitBox>(); 

            Debug.Log("Drücke F zum Benutzen");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            playerHealth = null;
            playerMovement = null;
            attackHitBox = null;
        }
    }

    void ApplyEffect()
    {
        switch (type)
        {
            case 0: // Heal
                playerHealth.Heal(healAmount);
                break;

            case 1: //  Damage Boost
                if (attackHitBox != null)
                    StartCoroutine(attackHitBox.DamageBoost(boostMultiplier, boostDuration));
                break;

            case 2: //  Speed Boost
                if (playerMovement != null)
                    StartCoroutine(SpeedBoost(boostMultiplier, boostDuration));
                break;
        }
    }

    IEnumerator SpeedBoost(float multiplier, float duration)
    {
        if (playerMovement == null) yield break;

        float originalSpeed = playerMovement.Speed;
        playerMovement.Speed *= multiplier;

        yield return new WaitForSeconds(duration);

        playerMovement.Speed = originalSpeed;
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