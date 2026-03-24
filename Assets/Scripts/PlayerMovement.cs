using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public MovementAnimation anime;
    public SpriteRenderer Sprite;
    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movment here:
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            horizontal += 1f;
            AnimationPlay(false,false,true);
            Sprite.flipX = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
            anime.walkSide(false,true);
        
        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= 1f;
            AnimationPlay(false,false,true);
            Sprite.flipX = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
            anime.walkSide(false,true);
        
        if (Input.GetKey(KeyCode.W))
        {
            vertical += 1f;
            AnimationPlay(true,false,false);
        }
        else if (Input.GetKeyUp(KeyCode.W))  
            anime.walkNorth(false,true);
        
        if (Input.GetKey(KeyCode.S))
        {
            vertical -= 1f;
            AnimationPlay(false,true,false);
        }
        else if (Input.GetKeyUp(KeyCode.S))  
            anime.walkSouth(false,true);

        Vector3 change = new Vector3(horizontal, vertical, 0f).normalized * Time.deltaTime * Speed;
        transform.position += change;
    }

    //Hir wird die animation aus gewalt
    void AnimationPlay(bool North, bool South, bool Side)
    {
        anime.walkNorth(North,North);

        anime.walkSouth(South,South);

        anime.walkSide(Side,Side);
    }
}
