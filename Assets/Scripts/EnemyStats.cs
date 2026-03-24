using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 20;
    public int maxhealth = 20;

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxhealth);

        Debug.Log("Enemy Hit ! Health Left  : " + health);
    }
}
