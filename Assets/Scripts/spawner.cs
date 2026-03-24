
using System.Threading;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject monster;
    public GameObject loot;

    int x;
    float y;
    float timer = 0f;
    float spawndauer = 6f;
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
     monstercreate();   
    }

    void monstercreate()
    {
        x = Random.Range(-5,5);
        y = Random.Range(-5,5);
        Vector3 pos = new Vector3(x,y, 0); 
        
        Instantiate(monster, pos, Quaternion.identity);
    }
    

}

