
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] monsters;
    
   
    


   
    float timer = 0f;
    private const float spawndauer = 6f;
    float wavesenemy = 5f; 
    int counter = 0;
    
    void Start()
    {
        
    }


    void Update()
    {
        
        timer += Time.deltaTime;

    if(counter < 3 )
    {
        if (timer >= spawndauer)
        {
            for(int a = 0; a < wavesenemy; a++)
            {
                spawnmonster();
            }
            timer = 0f;
            counter++;  
        }  
    }
    else 
        {
            Destroy(gameObject);
        }
    }
    void spawnmonster()
        {
            int maxversuche = 10;
            int randomIndex = Random.Range(0, monsters.Length);
            for (int versuche = 0; versuche < maxversuche; versuche++ )
            {    float x = Random.Range(-5,5);
                float y = Random.Range(-5,5);
                Vector3 pos = new Vector3(x,y, 0); 
                if(collisioncheck(pos))
                    {
                        Instantiate(monsters[randomIndex], pos, Quaternion.identity);
                        break;
                    }
                else
                    {
                        Debug.Log("Spawn belegt");
             }       
              }

        }
    bool collisioncheck(Vector3 pos)
        {
            float checkradius = 1f;
            LayerMask mask = LayerMask.GetMask("Player", "Enemy");
            Collider2D hit = Physics2D.OverlapCircle(pos, checkradius, mask);
            return hit == null;
        }

    
    

}

