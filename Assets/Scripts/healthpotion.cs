using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour
{
    public int type; // 0 = Heal, 1 = Damage, 2 = Speed
    public int healAmount = 25;
    public int damageAmount = 10;

    [Header("Sprites für Potion")]
    public Sprite healSprite;
    public Sprite damageSprite;
    public Sprite speedSprite;

    private bool playerInRange = false;

    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // SpriteRenderer holen
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Random Typ setzen (0 = Heal, 1 = Damage, 2 = Speed)
        type = Random.Range(0, 3);

        // Potion Aussehen entsprechend Typ setzen
        SetPotionLook();

        Debug.Log("Potion Type: " + type);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
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
        }
    }

    void ApplyEffect()
    {
        switch (type)
        {
            case 0: // Heal
                playerHealth.Heal(healAmount);
                break;

            case 1: // Damage
                playerHealth.TakeDamage(damageAmount);
                break;

            case 2: // Speed Boost
                if (playerMovement != null)
                {
                    StartCoroutine(SpeedBoost(2f, 5f));
                }
                break;
        }
    }

    IEnumerator SpeedBoost(float multiplier, float duration)
    {
        if (playerMovement == null) yield break;

        // Achte darauf, dass dein PlayerMovement eine öffentliche Speed-Variable hat
        float originalSpeed = playerMovement.Speed;

        playerMovement.Speed *= multiplier;

        yield return new WaitForSeconds(duration);

        playerMovement.Speed = originalSpeed;
    }

    // Funktion, die das Sprite/Farbe der Potion je nach Typ ändert
    void SetPotionLook()
    {
        if (spriteRenderer == null) return;

        switch (type)
        {
            case 0: // Heal
                spriteRenderer.sprite = healSprite;
                break;

            case 1: // Damage
                spriteRenderer.sprite = damageSprite;
                break;

            case 2: // Speed
                spriteRenderer.sprite = speedSprite;
                break;
        }
    }
}