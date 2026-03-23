using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1;

    private Sprite facingRight;
    private Sprite facingLeft;
    public Camera cam;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main; // or drag-assign via [SerializeField]
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Player here:
           Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (mouseWorld.x >= transform.position.x)
            sr.sprite = facingRight;
        else
            sr.sprite = facingLeft;


        // Movment here:
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 change = Vector3.right * Time.deltaTime * Speed;
            transform.position = transform.position + change;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 change = Vector3.left * Time.deltaTime * Speed;
            transform.position = transform.position + change;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 change = Vector3.up * Time.deltaTime * Speed;
            transform.position = transform.position + change;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 change = Vector3.down * Time.deltaTime * Speed;
            transform.position = transform.position + change;
        }
    }
}
