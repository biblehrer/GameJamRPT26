using UnityEngine;

public class EnemyDropIntervall : MonoBehaviour
{
    private float timer = 0f;
    public float spawnRadius = 2f;
    public GameObject dropPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            int dropCount = Random.Range(2, 5);

            for (int i = 0; i < dropCount; i++)
            {
                Drop();
                timer = 0;
            }
        }
    }

    void Drop()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomCircle.x, randomCircle.y, 0);
        Instantiate(dropPrefab, spawnPosition, Quaternion.identity);
    }
}
