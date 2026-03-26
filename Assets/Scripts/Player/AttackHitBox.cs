using UnityEngine;
using System.Collections;

public class AttackHitBox : MonoBehaviour
{
    public int damage = 10;

    public static float damageMultiplier = 1f;

    public IEnumerator DamageBoost(float multiplier, float duration)
    {
        float originalDamage = damageMultiplier;

        damageMultiplier *= multiplier;

        Debug.Log("Damage Boost aktiv: x" + damageMultiplier);

        yield return new WaitForSeconds(duration);

        damageMultiplier = originalDamage;

        Debug.Log("Damage Boost beendet");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("wall"))
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage((int)(damage * damageMultiplier));
            }
        }
    }


}