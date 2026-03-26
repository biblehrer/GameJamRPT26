using UnityEngine;

public class EnemyDropRan : MonoBehaviour
{
    public GameObject dropPrefab;
    public float spawnRadius = 1.2f; // wie weit um den zombie spawnt es

    public void whenDeath()
    {
        int dropCount = Random.Range(0, 3); 
        
        for (int i = 0; i < dropCount; i++)
        {
            SpawnDrop();
        }

        Destroy(gameObject);
    }

    private void SpawnDrop()
    {
        if (dropPrefab == null) return;

        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomCircle.x, randomCircle.y, 0);
        Instantiate(dropPrefab, spawnPosition, Quaternion.identity);
    }
}