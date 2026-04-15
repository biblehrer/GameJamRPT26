using UnityEngine;

public class WallEnemiesCount : MonoBehaviour
{
    public int currentEnemyCount;
    public float detectionRadius = 3f;
    public GameObject Spawner;
    private Transform playerTransform; // Nicht mehr public, da wir es automatisch suchen
    bool playerArrived = false;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    void Update()
    {
        // Falls kein Spieler gefunden wurde, abbrechen um Fehler zu vermeiden
        if (playerTransform == null) return;

        // Warten bis der Spieler in Reichweite ist
        if (!playerArrived)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);
            if (distance <= detectionRadius)
            {
                playerArrived = true;
            }
            return;
        }

        // Gegner im Spiel zählen
        currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        /*/ Welle gestartet?
        if (!enemiesSpawned)
        {
            if (currentEnemyCount > 0)
                enemiesSpawned = true;
        }*/

        if (Spawner == null && currentEnemyCount == 0 )//&& enemiesSpawned)
        {
            Destroy(gameObject);
        }
    }
}