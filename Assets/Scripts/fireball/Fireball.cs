using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 10;
    public float offset = 0; // Adjust this if the sprite faces the wrong way (try 90 or -90)
    public int dmg = 5;
    
    private Animator anim;
    private playerStats stats;

    void Start()
    {
        anim = GetComponent<Animator>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<playerStats>();
        stats.score--;
        SetElement();

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z; 
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        Vector2 lookDir = (Vector2)worldMousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, angle + offset);

        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    void SetElement()
    {
        if (stats == null) return;

        switch(stats.element)
        {
            case 0:
                Select(true, false, false);
                dmg = dmg *1;
                break;
            case 1:
                Select(false, true, false);
                dmg = dmg *2;
                break;
            case 2:
                Select(false, false, true);
                dmg = dmg *3;
                break;
        }
    }

    void Select(bool isRed, bool isBlue, bool isPink)
    {
        anim.SetBool("Red", isRed);
        anim.SetBool("Blue", isBlue);
        anim.SetBool("Pink", isPink);
    }

}