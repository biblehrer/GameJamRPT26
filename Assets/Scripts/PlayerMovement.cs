using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
