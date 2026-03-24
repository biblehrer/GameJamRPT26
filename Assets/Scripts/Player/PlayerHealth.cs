using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    public void Heal(int amount)
    {
        health += amount; 

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("Spieler geheilt! Leben: " + health);
    }

    void Update()
    {
         health = Mathf.Clamp(health, 0, maxHealth);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

}