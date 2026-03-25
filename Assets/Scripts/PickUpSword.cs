using System.ComponentModel;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    public GameObject Info;
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
                playerHealth.swordCollaction += 1;
                Destroy(gameObject);  
            }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playerHealth = col.gameObject.GetComponent<PlayerHealth>();
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            Info.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Info.SetActive(false);
        playerInRange = false;
    }
}
