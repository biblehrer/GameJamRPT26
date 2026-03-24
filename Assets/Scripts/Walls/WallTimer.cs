using UnityEngine;

public class WallTimer : MonoBehaviour
{
    private float timer = 0f;
    private float destroyTime = 60f; //nach wie vielen sekunden geht die wand kaputt

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    
}