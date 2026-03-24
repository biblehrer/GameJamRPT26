using UnityEngine;

public class WallEnemies : MonoBehaviour
{
    // bearbeiten wenn spawner fertig ist
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
