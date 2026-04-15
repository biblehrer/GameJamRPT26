using UnityEngine;

public class spawnLitch : MonoBehaviour
{
    public GameObject Litch;
    bool playerInRange = false;
    public GameObject Info;


    void Update()
    {
        if(playerInRange && Input.GetButton("ActionButten"));
    }

    void SpawnMonster()
    {
        Instantiate(Litch);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Info.SetActive(true);
        }
        else Info.SetActive(false);
    }
}
