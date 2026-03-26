using System.Collections.Generic;
using UnityEngine;

public class LootMonster : MonoBehaviour
{
    public List<GameObject> lootitems;
    [Range(0f, 1f)]
    public List<float> dropchance;
    
    
    void OnDestroy()
    {
        droploot();
    }
    void droploot()
    {
        float summe = 0;
        float rnd = Random.value;
        for(int i = 0; i < lootitems.Count; i++)
        {
            summe +=  dropchance[i];
            if(rnd <= summe )
            {
                Instantiate(lootitems[i],transform.position,Quaternion.identity);
                
                break;
            }
            
        }
    }
}
