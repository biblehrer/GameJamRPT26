using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
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
            horizontal += 1f;

        if (Input.GetKey(KeyCode.A)) 
            horizontal -= 1f;

        if (Input.GetKey(KeyCode.W)) 
            vertical += 1f;

        if (Input.GetKey(KeyCode.S))
            vertical -= 1f;

        Vector3 change = new Vector3(horizontal, vertical, 0f).normalized * Time.deltaTime * Speed;
        transform.position += change;
    }
}
