using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwordCountUI : MonoBehaviour
{
    public PlayerStats playerHealth;
    public TextMeshProUGUI[] swordTexts;
    void Start()
    {
        
    }

    void Update()
    {
        int i = 0;
        foreach (KeyValuePair<SwordType, int> entry in playerHealth.swordCollection)
        {
            swordTexts[i].text = "" + entry.Value;
            i++;
        }
    }
}
