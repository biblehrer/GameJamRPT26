using UnityEngine;
using UnityEngine.UI;

public class HPBarLogic : MonoBehaviour
{
    public PlayerHealth PlayerHp;
    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar();
    }

        void HPBar()
    {
        slider.maxValue = PlayerHp.maxHealth;
        slider.value = PlayerHp.health;
    }

}
