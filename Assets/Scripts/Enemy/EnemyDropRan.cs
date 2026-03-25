using UnityEngine;

public class EnemyDropRan : MonoBehaviour
{
    public GameObject dropPrefab;

    void OnDestroy()
    {
        int dropCount = Random.Range(0, 3); // 0, 1 oder 2
        Debug.Log(dropCount);
        
        for (int i = 0; i < dropCount; i++)
        {
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }
}