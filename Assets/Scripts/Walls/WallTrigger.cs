using UnityEngine;
public class WallTrigger : MonoBehaviour
{
    public WallTimer wall;

    //klappt nur wenn spieler rigidbody hat
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wall.StartTimer();
            // wenn spieler rein läuft wird der timer im wand script getriggert
        }
    }
}