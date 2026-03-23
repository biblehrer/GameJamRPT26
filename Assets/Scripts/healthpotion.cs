using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Geheilt! Aktuelles Leben: " + currentHealth);
    }
}