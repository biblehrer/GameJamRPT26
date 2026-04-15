using UnityEngine;

public class spawnLitch : MonoBehaviour
{
    public GameObject Litch;
    bool playerInRange = false;
    public GameObject Info;


    void Update()
    {
        if(playerInRange) if(Input.GetButton("ActionButten")) SpawnMonster();
    }

    void SpawnMonster()
    {
        Litch.SetActive(true);
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
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
