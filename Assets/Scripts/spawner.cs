using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] monsters;
    bool playerinRange = false;
    float timer = 0f;
    public const float spawndauer = 6f;
    public float gegnerprowelle = 5f; 
    public int wellen = 0;
    public float xMaxRange;
    public float yMaxRange;
    public float yMinRange;
    public float xMinRange;

    void Start()
    {
        
    }

    void Update()
    {
        if(playerinRange)     
        {        
            timer += Time.deltaTime;

            if(wellen >= 0)
            {
                if (timer >= spawndauer)
                {
                    for(int a = 0; a < gegnerprowelle; a++)
                    {
                        spawnmonster();
                    }
                    timer = 0f;
                    wellen++;  
                }  
            }
            else 
            {
                Destroy(gameObject);
            }        
        }
    }

    void spawnmonster()
    {
        int maxversuche = 10;
        int randomIndex = Random.Range(0, monsters.Length);
        for (int versuche = 0; versuche < maxversuche; versuche++ )
        {    
            float x = Random.Range(xMinRange, xMaxRange);
            float y = Random.Range(yMinRange, yMaxRange);
            Vector3 pos = new Vector3(x, y, 0); 
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerinRange = true;
        }
    }
}