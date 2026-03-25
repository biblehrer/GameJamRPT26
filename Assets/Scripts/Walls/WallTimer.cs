using UnityEngine;
public class WallTimer : MonoBehaviour
{
    private float timer = 0f;
    public float destroyTime = 60f;
    private bool triggered = false;

    public void StartTimer()
    {
        triggered = true;
    }

    void Update()
    {
        if (triggered)
        {
            timer += Time.deltaTime; //timer

            if (timer >= destroyTime ) // wenn destroytime erreicht, dann wand weg
            {
                Destroy(gameObject);
            }
        }
    }
}