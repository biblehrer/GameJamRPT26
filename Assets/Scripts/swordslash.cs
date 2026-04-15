using UnityEngine;

public class swordslash : MonoBehaviour
{

    Animator animator;
    SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isAttacking(bool isAttacking, bool flip)
    {
        if (!didStart)
        {
            Start();
        }
        animator.SetBool("isAttacking", isAttacking);   
        isAttacking = false;     
        sprite.flipX = flip;
    }
}
