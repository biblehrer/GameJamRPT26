using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class TrapChestLoot : MonoBehaviour
{
    public GameObject door;
    public GameObject spawner;
    public Sprite closedSprite;
    public Sprite openSprite;
    public GameObject Info;
    bool isOpen = false;
    bool playerInRange = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        door.SetActive(false);
        spawner.SetActive(false);
        Info.SetActive(false);
    }
    void Update()
    {
        if (playerInRange && !isOpen && Input.GetButton("Use"))
        {
            OpenChest();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            if (!isOpen) Info.SetActive(true);
        }
    }

    void OpenChest()
    {
        isOpen = true;
        door.SetActive(true);
        spriteRenderer.sprite = openSprite;
        spawner.SetActive(true);
        Info.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            if (!isOpen) Info.SetActive(false);
        }
    }
}