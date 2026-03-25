using UnityEngine;

public class Attack_1 : MonoBehaviour
{   
    public GameObject hitbox;
    public Transform RotationArea;
     Vector3 startRotation;
     Vector3 endRotation;
    private float rotationTime = 0f;
    private bool rotationDone = false;
    PlayerMovement playerMovement;
    private bool attacking = false;

    private float cooldown = 0.50f;
    private float timer = 0f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        AttackAnimation();

        if (!attacking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartAttack();
                Attack();
            }
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                timer = 0;
                attacking = false;
                hitbox.SetActive(attacking);
            }
        }
    }

    void Attack()
    {   
        attacking = true;
        hitbox.SetActive(attacking);
    }

    void StartAttack()
    {
        switch (playerMovement.faceingState)
        {
            case 0:
                startRotation = new Vector3(0, 0, 30f);
                endRotation   = new Vector3(0, 0, -30f);
                break;
            case 1:
                startRotation = new Vector3(0, 0, -211f);
                endRotation   = new Vector3(0, 0, -136f);
                break;
            case 2:
                startRotation = new Vector3(0, 0, -59f);
                endRotation   = new Vector3(0, 0, -131f);
                break;
            case 3:
                startRotation = new Vector3(0, 0, 59f);
                endRotation   = new Vector3(0, 0, 131f);
                break;
        }

        rotationTime = 0f;
        rotationDone = false;
    }

    void AttackAnimation()
    {
        if (rotationDone || RotationArea == null) return;

        rotationTime += Time.deltaTime;
        float t = Mathf.Clamp01(rotationTime / cooldown);

        RotationArea.rotation = Quaternion.Slerp(Quaternion.Euler(startRotation),Quaternion.Euler(endRotation),Mathf.SmoothStep(0f, 1f, t));

        if (t >= 1f) rotationDone = true;
    }
}