using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject Info;
    public GameObject coin;

    private bool playerInRange = false;
    PlayerStats player;

    void Update()
    {
        if (playerInRange && Input.GetButton("ActionButten"))
        {   
            shopUI.SetActive(true);
        }
        if (player != null)
        {
            TextMeshProUGUI coinT = coin.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            coinT.text = "" + player.gold;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Info.SetActive(true);
            player = other.GetComponent<PlayerStats>();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Info.SetActive(false);
            shopUI.SetActive(false);
        }
    }

    public void BuyHealth()
    {   
        if (player.gold >= 5)
        {
            player.health += 25;
            player.gold -= 5;
        }
    }

    public void BuySword()
    {
        
        if (player.gold >= 10)
        {
            player.swordCollection[SwordType.BoneSword] += 1;
            player.gold -= 10;
        }
    }

    public void BuySword2()
    {
        
        if (player.gold >= 20)
        {
            player.swordCollection[SwordType.Netherrite] += 1;
            player.gold -= 20;
        }
    }


    public void Close()
    {
        shopUI.SetActive(false);
    }
}
