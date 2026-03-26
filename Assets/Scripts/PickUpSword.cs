using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    public GameObject Info;

    public SwordType swordType = SwordType.WoodSword;

    bool playerInRange;
    PlayerHealth playerHealth;

    void Start()
    {
        playerInRange = false;
        Info.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && playerInRange)
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
            playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerInRange = false;
            Info.SetActive(false);
        }

    }
}
