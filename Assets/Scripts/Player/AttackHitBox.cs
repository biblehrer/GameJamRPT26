using UnityEngine;
using System.Collections;

public class AttackHitBox : MonoBehaviour
{
    public int damage = 10;

    public static float damageMultiplier = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage((int)(damage * damageMultiplier));
            }
        }
    }

    public IEnumerator DamageBoost(float multiplier, float duration)
    {
        float originalDamage = damageMultiplier;

        damageMultiplier *= multiplier;

        Debug.Log("Damage Boost aktiv: x" + damageMultiplier);

        yield return new WaitForSeconds(duration);

        damageMultiplier = originalDamage;

        Debug.Log("Damage Boost beendet");
    }
}