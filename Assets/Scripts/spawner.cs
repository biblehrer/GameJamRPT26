using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] monsters;
    bool playerInRange = false;
    float timer = 0f;
    public const float spawnDauer = 6f;
    public float gegnerProWelle = 5f;
    public int wellen = 0;
    public float xMaxRange;
    public float yMaxRange;
    public float yMinRange;
    public float xMinRange;

    void Update()
    {
        if (playerInRange)
        {
            timer += Time.deltaTime;

            if (wellen >= 0)
            {
                if (timer >= spawnDauer)
                {
                    for (int a = 0; a < gegnerProWelle; a++)
                    {
                        SpawnMonster();
                    }
                    timer = 0f;
                    wellen--;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void SpawnMonster()
    {
        int maxVersuche = 10;
        int randomIndex = Random.Range(0, monsters.Length);

        for (int versuche = 0; versuche < maxVersuche; versuche++)
        {
            Vector3 spawnPos = new Vector3(
                transform.position.x + Random.Range(xMinRange, xMaxRange),
                transform.position.y + Random.Range(yMinRange, yMaxRange),
                0f
            );

            if (CollisionCheck(spawnPos))
            {
                Instantiate(monsters[randomIndex], spawnPos, Quaternion.identity);
                break;
            }
            else
            {
                Debug.Log("Spawn belegt");
            }
        }
    }

    bool CollisionCheck(Vector3 pos)
    {
        float checkRadius = 1f;
        LayerMask mask = LayerMask.GetMask("Player", "Enemy");
        Collider2D hit = Physics2D.OverlapCircle(pos, checkRadius, mask);
        return hit == null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}
