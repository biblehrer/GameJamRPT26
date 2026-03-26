using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    public GameObject Info;
    public Sprite[] sprites;

    public SwordType swordType = SwordType.WoodSword;

    SpriteRenderer spriteRenderer;
    bool playerInRange;
    PlayerHealth playerHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInRange = false;
        Info.SetActive(false);

        int index = (int)swordType;
        if (index < sprites.Length)
            spriteRenderer.sprite = sprites[index];
    }

    void Update()
    {
        if (Input.GetButton("ActionButten") && playerInRange)
        {
            playerHealth.swordCollection[swordType] += 1;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerInRange = true;
            Info.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            Info.SetActive(false);
        }
    }
}
