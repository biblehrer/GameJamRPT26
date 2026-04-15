using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalpoint : MonoBehaviour
{
    [Header("Game UI")]
    public GameObject victoryCanvas;
    public GameObject gameOverCanvas;

    public PlayerStats playerHealth;
    private bool isGameOver = false;
    private void Start()
    {
        if (victoryCanvas != null)
            victoryCanvas.SetActive(false);

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);
    }
   
    private void Update()
    {
        if (playerHealth != null && playerHealth.health <= 0)
        {
            isGameOver = true;
            ShowGameOverScreen();
        }
        if (!isGameOver)
        {
            Time.timeScale = 1f; // Unpause game
        }
    }
       
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Portal - Level Complete!");
            ShowVictoryScreen();
        }
    }
    private void ShowVictoryScreen()
    {
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
            Time.timeScale = 0f; //Pause game
        }
    }
    public void ShowGameOverScreen()
    {
        if (isGameOver && gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void PlayAgain()
    {
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
