using UnityEngine;

public class ButtenInfo : MonoBehaviour
{
    public bool isActionButten = false;
    Animator animator;
    bool isControllerConnected;
    void Awake()
    {
        isControllerConnected = Input.GetJoystickNames().Length > 0 && Input.GetJoystickNames()[0] != "";
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isControllerConnected = Input.GetJoystickNames().Length > 0 && Input.GetJoystickNames()[0] != "";
        if (isControllerConnected)
        {
            if(isActionButten)
                AnimationSellect(false,false,false,true,false);
            else    AnimationSellect(false,false,true,false,false);
        }
        else
        {
            if(isActionButten)
                AnimationSellect(false,false,false,false,true);
            else    AnimationSellect(true,false,false,false,false);
        }
    }

    void AnimationSellect(bool Mouse0, bool Mouse1, bool X, bool A, bool E)
    {
        animator.SetBool("ButtenMouse0", Mouse0);
        animator.SetBool("ButtenMouse1", Mouse1);
        animator.SetBool("ButtenX", X);
        animator.SetBool("ButtenA", A);
        animator.SetBool("ButtenE", E);
        
    }
}
