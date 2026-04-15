using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Pet : MonoBehaviour
{
    public GameObject Info;
    private GameObject player;
    Animator animator;
    public float speed = 2f;         // Bewegungsgeschwindigkeit
    public float stopDistance = 1.25f;  // Abstand, bei dem der Enemy stoppt
    public bool isfollowing = false;
    public float rotationSpeed = 5f; // Drehgeschwindigkeit
    public bool inRang = false;
   
    void Start()
    {
        // Spieler über Tag suchen
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {        
        if (isfollowing)
        {
            LookAtPlayer();
            MoveTowardsPlayer();
            animator.SetBool("walking", true);
        }

        if (inRang)
        {
            if(Input.GetButton("ActionButten")) isfollowing = true;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!isfollowing) Info.SetActive(true);
            inRang = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Info.SetActive(false);
            inRang = false;
        }
    }
}