using UnityEngine;

public class coin : MonoBehaviour
{

    public float spinSpeed = 180f;
    public Vector3 spin = Vector3.up;
    PlayerStats playerStats;
    public int value = 1;

    public float detectRange = 8f;
    public float flySpeed = 5f;
    public float speedRamp = 2f;

    private Transform player;
    bool isFlying = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
        
    }

    void Update()
    {
        transform.Rotate(spin, spinSpeed * Time.deltaTime);

        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

        
        if (dist <= detectRange)
            isFlying = true;

        if (isFlying)
        {
            float currentSpeed = flySpeed + (speedRamp * (1f - dist / detectRange));
            transform.position = Vector3.MoveTowards(transform.position,player.position,currentSpeed * Time.deltaTime);
        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerStats = col.gameObject.GetComponent<PlayerStats>();
            playerStats.gold += value;
            Destroy(gameObject);
        }
    }
}
