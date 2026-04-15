using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject Info;
    public List<GameObject> itemsSprites;
    public GameObject shopUI;
    public GameObject ShopItems;

    private bool playerInRange = false;
    private int[] currentItems;
    int[] type;
    private int maxItems = 3;
    PlayerStats player;

    void Start()
    {   
        currentItems = new int[maxItems];
        type = new int[maxItems];
        for (int i =0; i<maxItems; i++)
        {
            currentItems[i] = Random.Range(0, itemsSprites.Count);
            type[i] = Random.Range(0,4);
        }
    }


    void Update()
    {
        if (playerInRange && Input.GetButton("ActionButten"))
        {   
            SetItems();
            shopUI.SetActive(true);
            Destroy(gameObject);
        }
        SetItems();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Info.SetActive(true);
            player = other.GetComponent<PlayerStats>();;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Info.SetActive(false);
            shopUI.SetActive(false);
            player = null;
        }
    }

    public void Buy(int i)
    {   
        player.swordCollection[(SwordType)type[i]] += 1;
    }

    void SetItems()
    {
        for (int i=0; i<ShopItems.transform.childCount; i++)
        {
            UnityEngine.UI.Image sr = ShopItems.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>();
            PickUpSword a = itemsSprites[currentItems[i]].GetComponent<PickUpSword>();
            sr.sprite = a.sprites[type[i]];
        }
    }

    public void Close()
    {
        shopUI.SetActive(false);
    }
}
