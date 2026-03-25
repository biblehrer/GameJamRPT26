using UnityEngine;

public class Attack_1 : MonoBehaviour
{   
    public GameObject[] hitbox;

    PlayerHealth playerStats;
    PlayerMovement playerMovement;

    public Transform RotationArea;
    private Vector3 startRotation;
    private Vector3 endRotation;
    private float rotationTime = 0f;
    private bool rotationDone = false;

    private bool attacking = false;
    private float cooldown = 0.50f;
    private float timer = 0f;

    private int selectedSword = 0;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStats    = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        selectedSword = Mathf.Clamp((int)playerStats.isUsingSword, 0, hitbox.Length - 1);

        AttackAnimation();

        if (!attacking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartAttack();
                Attack();
            }
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                timer = 0f;
                attacking = false;
                hitbox[selectedSword].SetActive(false);
            }
        }
    }

    void Attack()
    {
        attacking = true;
        hitbox[selectedSword].SetActive(true);
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

    void SwordSelect()
    {
        switch (selectedSword)
        {
            case 0:

                break;
        }
    }
}