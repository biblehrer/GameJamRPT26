using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

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
        Debug.Log("Health: " + playerHealth.health + " | Reload: " + Reload);

        if (playerHealth != null && playerHealth.health <= 0 && !isGameOver)
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
        Time.timeScale = 1f; //unpause
        Reload++;
    }

    public static int Reload = 0;
}
