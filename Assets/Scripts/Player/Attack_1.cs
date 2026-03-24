using UnityEngine;

public class Attack_1 : MonoBehaviour
{   
    public GameObject hitbox;

    private bool attacking = false;

    private float cooldown = 0.25f;
    private float timer = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                timer = 0;
                attacking = false;
                hitbox.SetActive(attacking);
            }
        }
    }

    void Attack()
    {   
        attacking = true;
        hitbox.SetActive(attacking);
    }
}