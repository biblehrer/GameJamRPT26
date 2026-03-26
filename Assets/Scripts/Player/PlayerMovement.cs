using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject RotationArea;
    public GameObject playerSprite;
    public MovementAnimation anime;
    public SpriteRenderer Sprite;
    public float Speed = 1;
    public float rotationSpeed = 5f;
    public int faceingState =0;// 0 Up; 1 Down; 2 Right; 3 Left;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Movement here:
        if (horizontal > 0f)
        {
            faceingState = 2;
            AnimationPlay(false, false, true);
            facingRight = true;
        }
        else if (horizontal < 0f)
        {
            faceingState = 3;
            AnimationPlay(false, false, true);
            facingRight = false;
        }
        else if (vertical > 0f)
        {
            faceingState = 0;
            AnimationPlay(true, false, false);
        }
        else if (vertical < 0f)
        {
            faceingState = 1;
            AnimationPlay(false, true, false);
        }
        else
        {
            // No input - stop animations
            anime.walkSide(false, true);
            anime.walkNorth(false, true);
            anime.walkSouth(false, true);
        }

        Vector3 change = new Vector3(horizontal, vertical, 0f).normalized * Time.deltaTime * Speed;
        transform.position += change;
    }
    
}
