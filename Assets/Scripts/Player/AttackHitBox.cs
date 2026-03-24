using UnityEngine;

public class AttackHitBox : MonoBehaviour
{   
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy") //enemy tag ??
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats == null)
                return;
            
            enemyStats.health -= damage;
        }
    }
}
