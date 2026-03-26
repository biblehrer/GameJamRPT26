using UnityEngine;
using System.Collections;

public class EnemyWall : MonoBehaviour
{
    public GameObject wallPrefab;
    public float interval = 10f;
    
    private Transform player;

    IEnumerator Start()
    {
        GameObject found = GameObject.FindWithTag("Player");
        if (found != null) player = found.transform;

        while (true)
        {
            yield return new WaitForSeconds(interval);
            if (player != null) SpawnWalls();
        }
    }

    void SpawnWalls()
    {
        Vector2 p = player.position;
        float dist = 1f; // Abstand vom Spieler

        Instantiate(wallPrefab, new Vector3(p.x + dist, p.y, 0), Quaternion.identity);
        Instantiate(wallPrefab, new Vector3(p.x - dist, p.y, 0), Quaternion.identity);
        Instantiate(wallPrefab, new Vector3(p.x, p.y + dist, 0), Quaternion.identity);
        Instantiate(wallPrefab, new Vector3(p.x, p.y - dist, 0), Quaternion.identity);
    }
}
