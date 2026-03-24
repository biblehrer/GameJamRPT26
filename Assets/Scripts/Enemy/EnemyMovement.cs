using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public float speed = 2f;         // Bewegungsgeschwindigkeit
    public float stopDistance = 0.25f;  // Abstand, bei dem der Enemy stoppt
    public float activationDistance = 20f;
    public float rotationSpeed = 5f; // Drehgeschwindigkeit
   
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
        // Richtung berechnen (Rechts/Links)
        float directionX = player.transform.position.x - transform.position.x;
        float targetYAngle = directionX > 0 ? 0f : 180f;
        
        Quaternion targetRotation = Quaternion.Euler(0, targetYAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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