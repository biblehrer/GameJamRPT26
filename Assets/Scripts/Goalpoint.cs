using UnityEngine;

public class goalpoint : MonoBehaviour
{
   
    public GameObject winUI;
    public GameObject gameoverUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.CompareTag("Player"))
        {   
            gameoverUI.SetActive(false);
            winUI.SetActive(true);
           
        }
    }
}
