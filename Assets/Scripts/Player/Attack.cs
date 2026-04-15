using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Attack : MonoBehaviour
{   
    public GameObject[] hitbox;
    public swordslash swordslash;

    PlayerStats playerStats;
    PlayerMovement playerMovement;
    public Camera cam;

    public Transform RotationArea;
    private Vector3 startRotation;
    private Vector3 endRotation;
    public float rotationTime = 0f;
    private bool rotationDone = false;

    Vector2 mousePos;
    Vector2 rightStick;

    private bool attacking = false;
    private float cooldown = 0.50f;
    private float timer = 0f;

    private int selectedSword = 0;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStats    = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        selectedSword = Mathf.Clamp((int)playerStats.isUsingSword, 0, hitbox.Length - 1);

        AttackAnimation();

        if (!attacking)
        {
            if (Input.GetButton("Use"))
            {
                StartAttack();
                ExecuteAttack();
            }
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                timer = 0f;
                attacking = false;
                DeactivateAllSwords();
            }
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rightStick = new Vector2(Input.GetAxisRaw("RightStickX"), Input.GetAxisRaw("RightStickY"));
    }

    void FixedUpdate()
    {

    }

    int GetFacingFromMouse()
    {
        Vector2 lookDir = mousePos - (Vector2) transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-90;

        if (lookDir.magnitude < 0.1f)
        return playerMovement.faceingState;

        // Normalize to 0–360
        if (angle < 0) angle += 360f;

        if (angle >= 315f || angle < 45f)  return 0; // Right
        if (angle >= 45f  && angle < 135f) return 3; // Up
        if (angle >= 135f && angle < 225f) return 1; // Left
        return 2; // Down
    }
    void ExecuteAttack()
    {
        attacking = true;
        hitbox[selectedSword].SetActive(true);
    }

    void StartAttack()
    {
        switch (GetFacingFromMouse())
        {
            case 0:
                startRotation = new Vector3(0, 0, 30f);
                endRotation   = new Vector3(0, 0, -30f);
                swordslash.isAttacking(true,false);
                break;
            case 1:
                startRotation = new Vector3(0, 0, -211f);
                endRotation   = new Vector3(0, 0, -136f);
                swordslash.isAttacking(true,true);
                break;
            case 2:
                startRotation = new Vector3(0, 0, -59f);
                endRotation   = new Vector3(0, 0, -131f);
                swordslash.isAttacking(true,false);
                break;
            case 3:
                startRotation = new Vector3(0, 0, 59f);
                endRotation   = new Vector3(0, 0, 131f);
                swordslash.isAttacking(true,true);
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

    void DeactivateAllSwords()
{
    for (int i = 0; i < hitbox.Length; i++)
    {
        hitbox[i].SetActive(false);
        swordslash.isAttacking(false,false);
    }
}
}