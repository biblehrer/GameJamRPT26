using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    Animator animator;
    public Transform HatGamObject;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void walkNorth(bool isWalking,bool isLooking)
    {
        animator.SetBool("lookNorth", isLooking);
        animator.SetBool("walkNorth", isWalking);
        
    }

    public void walkSouth(bool isWalking,bool isLooking)
    {
        animator.SetBool("lookSouth", isLooking);
        animator.SetBool("walkSouth", isWalking);
        
    }

    public void walkSide(bool isWalking,bool isLooking)
    {
        animator.SetBool("lookSide", isLooking);
        animator.SetBool("walkSide", isWalking);
        
    }

    public void idle(bool nothing)
    {
        animator.SetBool("walkNorth", nothing);
        animator.SetBool("walkSouth", nothing);
        animator.SetBool("walkSide", nothing);
    }

    public void hatMoveUp()
    {
        HatGamObject.position = transform.position + new Vector3(0,0.3699999f,0);
    }

    public void hatMoveDown()
    {
        HatGamObject.position = transform.position + new Vector3(0,0.319f,0);
    }
}
