using UnityEngine;

public class spawnLitch : MonoBehaviour
{
    public GameObject Litch;
    public GameObject door;
    bool playerInRange = false;
    public GameObject Info;


    void Start()
    {
        door.SetActive(false);
    }
    void Update()
    {
        if(playerInRange) if(Input.GetButton("ActionButten")) SpawnMonster();
    }

    void SpawnMonster()
    {
        door.SetActive(true);
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
