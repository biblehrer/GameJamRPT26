
using System.Threading;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject monster;

   
    float timer = 0f;
    private const float spawndauer = 6f;
    float waves = 5f;
    
    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawndauer)
        {
            for(int i = 0; i < waves; i++)
            {
                spawnmonster();
            }
            timer = 0f;
        }    
    }

    void spawnmonster()
    {
        float x = Random.Range(-5,5);
        float y = Random.Range(-5,5);
        Vector3 pos = new Vector3(x,y, 0); 
        
        Instantiate(monster, pos, Quaternion.identity);
    }

    
    

}

