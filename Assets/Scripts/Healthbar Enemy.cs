using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarEnemy : MonoBehaviour
{
    public Slider Healthbar;
    public EnemyStats health;
    void Start()
    {
        
    }

    void Update()
    {
        Healthbar.value = 0.5f;

        Healthbar.value = (float)health.health / health.maxhealth;
        
    }
}
