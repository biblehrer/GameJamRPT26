using UnityEngine;
using UnityEngine.SceneManagement;
public class gameover : MonoBehaviour
{
    public GameObject Gameover ;
    public GameObject gamewin ;
    public GameObject button;
    public PlayerHealth player ;
    public GameObject spawner;
    void Start()
    {
        
    }
 
    void Update()
    {
        if (player.health<=0)
    {
        Gameover.SetActive(true);
         button.SetActive(true);
    }
    /*if (spawner.transform.childCount == 0)
    {
        gamewin.SetActive(true);
         button.SetActive(true);
    }*/
    
    }
    public void eppstein()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
