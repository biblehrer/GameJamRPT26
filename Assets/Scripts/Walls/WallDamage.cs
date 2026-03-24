using UnityEngine;
// bearbeiten sobald der spieler schaden macht

public class WallDamage : MonoBehaviour
{
    private float health = 50;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage; 
    }
}