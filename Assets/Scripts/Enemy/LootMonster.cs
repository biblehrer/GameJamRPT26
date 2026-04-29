using System.Collections.Generic;
using UnityEngine;

public class LootMonster : MonoBehaviour
{
    public List<GameObject> lootitems;
    [Range(0f, 1f)]
    public List<float> dropchance;
    
    public float XP = 10;
    LevelSystem levelSystem;

    void GiveXP()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        levelSystem = player.GetComponent<LevelSystem>();
        levelSystem.AddXP(XP);
    }
    public void droploot()
    {
        GiveXP();
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
