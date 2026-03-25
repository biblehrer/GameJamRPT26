using UnityEngine;

public class WallEnemies : MonoBehaviour
{
    public GameObject spawner;

    void Update()
    {
        if (spawner == null)
        {
            Destroy(gameObject);
        }
    }
}