using UnityEngine;
using UnityEngine.SceneManagement;

public class goalpoint : MonoBehaviour
{
    [Header("Game UI")]
    public GameObject victoryCanvas;
    public GameObject gameOverCanvas;

    public PlayerHealth playerHealth;
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
        if (!isGameOver && playerHealth != null && playerHealth.health <= 0)
        {
            isGameOver = true;
            ShowGameOverScreen();
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
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f; // Pause game
        }
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f; // Unpause game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
