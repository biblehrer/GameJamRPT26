using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public float speed = 3f;        // Bewegungsgeschwindigkeit
    public float stopDistance = 1f; // Abstand, bei dem der Enemy stoppt
    public float activationDistance = 20f;

    void Start()
    {
        // Spieler über Tag suchen
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (distanceToPlayer <= activationDistance) // aktivationsdistance
        {
            LookAtPlayer();
            MoveTowardsPlayer();
        }
    }

    void LookAtPlayer()
    {
        // Enemy dreht sich zum Spieler (Sprite-Oben zeigt auf Spieler)
        transform.up = player.transform.position - transform.position;
    }

    void MoveTowardsPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // Nur bewegen wenn außerhalb der Stopp-Distanz
        if (distance > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}