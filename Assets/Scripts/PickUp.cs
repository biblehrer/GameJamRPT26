using System.ComponentModel;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isSword;
    public GameObject Info;

    void Start()
    {
        Info.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            Info.SetActive(true);
            
            if (Input.GetMouseButtonDown(1))
            {
                if (isSword)
                {
                    PlayerHealth player = col.gameObject.GetComponent<PlayerHealth>();
                    player.swordCollaction += 1;
                    Destroy(gameObject);
                }
                    
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Info.SetActive(false);
    }
}
