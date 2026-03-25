using UnityEngine;

public class WallEnemies : MonoBehaviour
{
    public Transform playerTransform; 
    public float detectionRadius = 3f; // wie weit wird es erkannt
    
    private bool playerArrived = false;
    private bool enemiesSpawned = false;

    void Update()
    {
        // Warten bis der Spieler in Reichweite
        if (!playerArrived)
        {
            if (playerTransform != null) 
            {
                float distance = Vector2.Distance(transform.position, playerTransform.position);
                if (distance <= detectionRadius)
                {
                    playerArrived = true;
                }
            }
            return; 
        }

        // Gegner im Spiel zählen
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // welle gestartet?
        if (!enemiesSpawned)
        {
            if (currentEnemyCount > 0)
            {
                enemiesSpawned = true;
            }
        }
        // Wand löschen, sobald alle Gegner besiegt wurden
        else
        {
            if (currentEnemyCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}