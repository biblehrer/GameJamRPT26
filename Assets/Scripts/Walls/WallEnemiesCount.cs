using UnityEngine;

public class WallEnemiesCount : MonoBehaviour
{
    public Transform playerTransform;
    public float detectionRadius = 3f;
    public GameObject spawner;

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
                    playerArrived = true;
            }
            return;
        }

        // Gegner im Spiel zählen
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        // Welle gestartet?
        if (!enemiesSpawned)
        {
            if (currentEnemyCount > 0)
                enemiesSpawned = true;
        }

        // Spawner weg = Wand weg (vor dem Enemyzählen prüfen)
        if (spawner == null && currentEnemyCount == 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}