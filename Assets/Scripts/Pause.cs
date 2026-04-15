using UnityEditor.Rendering;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject background;
    bool backgroundstatus = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(backgroundstatus == false)
            {
                background.SetActive(true);
                backgroundstatus = true;
                Time.timeScale = 0;
            }
            else 
            {
                background.SetActive(false);
                backgroundstatus = false;
                Time.timeScale = 1;

            }
            
        }
    }
}
