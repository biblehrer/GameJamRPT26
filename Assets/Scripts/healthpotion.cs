using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healAmount = 25;

    private bool playerInRange = false;
    private PlayerHealth playerHealth;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Debug.Log("Potion benutzt!");

                Destroy(gameObject); // Potion verschwindet
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerHealth = other.GetComponent<PlayerHealth>();

            Debug.Log("Drücke F zum Heilen");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerHealth = null;
        }
    }
}