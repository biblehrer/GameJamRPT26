using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject gameOver ;
    public GameObject gameWin ;
    public GameObject button;
    public PlayerStats player ;
    public GameObject spawner;
    
    void Start()
    {
        
    }
 
    void Update()
    {
        if (player.health<=0)
        {
            gameOver.SetActive(true);
            button.SetActive(true);
        }
    /* This does not work
    if (spawner.transform.childCount == 0)
    {
        gamewin.SetActive(true);
        button.SetActive(true);
    }*/
    
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
