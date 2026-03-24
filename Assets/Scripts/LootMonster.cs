using UnityEngine;

public class LootMonster : MonoBehaviour
{
    public GameObject loot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnDestroy()
    {
        Instantiate(loot, transform.position,Quaternion.identity);
    }
}
