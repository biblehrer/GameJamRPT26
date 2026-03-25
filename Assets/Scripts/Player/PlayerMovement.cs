using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject RotationArea;
    public GameObject playerSprite;
    public MovementAnimation anime;
    public SpriteRenderer Sprite;
    public float Speed = 1;
    public float rotationSpeed = 5f;
    bool facingRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();

        Movement();
    }

    //Hir wird die animation aus gewalt
    void AnimationPlay(bool North, bool South, bool Side)
    {
        anime.walkNorth(North,North);

        anime.walkSouth(South,South);

        anime.walkSide(Side,Side);
    }


    void PlayerRotation()
    {
        float targetYAngle = facingRight ? 0f : 180f;
        
        Quaternion targetRotation = Quaternion.Euler(0, targetYAngle, 0);
        playerSprite.transform.rotation = Quaternion.Lerp(playerSprite.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Movement()
    {
        float horizontal = 0f;
        float vertical = 0f;

        

        // Movment here:
        if (Input.GetKey(KeyCode.D))
        {
            horizontal += 1f;
            AnimationPlay(false,false,true);
            facingRight = true;
            RotationArea.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (Input.GetKeyUp(KeyCode.D))
            anime.walkSide(false,true);
            
        if (Input.GetKey(KeyCode.A))
        {
            horizontal -= 1f;
            AnimationPlay(false,false,true);
            facingRight = false;
            RotationArea.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (Input.GetKeyUp(KeyCode.A))
            anime.walkSide(false,true);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            anime.walkSide(false, true);
            vertical = 0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vertical += 1f;
            AnimationPlay(true,false,false);
            RotationArea.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.W))  
            anime.walkNorth(false,true);
            
        if (Input.GetKey(KeyCode.S))
        {
            vertical -= 1f;
            AnimationPlay(false,true,false);
            RotationArea.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (Input.GetKeyUp(KeyCode.S))  
            anime.walkSouth(false,true);

        
        Vector3 change = new Vector3(horizontal, vertical, 0f).normalized * Time.deltaTime * Speed;
        transform.position += change;

        if (horizontal == 0 && vertical ==0)
            anime.walkSide(false,true);
        if (vertical == 0 && horizontal ==0)
            anime.walkSouth(false,true);
    }
    
}
