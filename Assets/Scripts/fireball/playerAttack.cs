using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Vector2 mousePos;
    public Camera cam;
    playerMovement move;
    public GameObject PrefabFireBall;
    public float speed = 10f;
    public UI ui;
    public PlayerAnimations anime;

    void Start()
    {        
        move = GetComponent<playerMovement>();
    }

    void Update()
    {
        if(ui.timer > 0) if (Input.GetButtonDown("use")) anime.attackAnim(true);
    }


    public void Attack()
    {
        if (move.isFacingRight)
        {
            Instantiate(PrefabFireBall, transform.position + transform.forward * 10f, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(PrefabFireBall, transform.position + transform.forward * 10f, Quaternion.Euler(0, 180, 0));
        }
        anime.attackAnim(false);
        anime.isIDLE = true; 
    }
}
