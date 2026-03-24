using UnityEngine;

public class WallEnemies : MonoBehaviour
{
    public GameObject spawner;
    public float EnemyAmount = 10;

    void Start()
    {
        
    }

    void Update()
    {
        if (EnemyAmount == 0)
        {
            Destroy(gameObject);
        }
    }
}
