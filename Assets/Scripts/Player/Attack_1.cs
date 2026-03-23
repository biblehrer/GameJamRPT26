using JetBrains.Annotations;
using UnityEngine;

public class Attack_1 : MonoBehaviour
{   
    public GameObject anchorPrefab;
    public GameObject swordPrefab;

    GameObject anchor;
    GameObject sword;
    float rotated = 0f;
    float rotationSpeed = 360f; // Grad pro Sekunde
    float halfAngle = 135 / 2f;

    void Attack_1Start()
    {   
        if (anchor != null || sword != null)
            return;

        anchor = Instantiate(
            anchorPrefab,
            transform.position,
            Quaternion.Euler(0, 0, transform.eulerAngles.z - halfAngle),
            transform
        );

        sword = Instantiate(swordPrefab, new Vector3(0, 2, 0), Quaternion.identity, anchor.transform);
        rotated = 0;
        anchor.transform.Rotate(0,0,halfAngle);
    }



    void Update()
    {   
        if (Input.GetKey(KeyCode.F))
        {   
            Debug.Log("dawd");
            Attack_1Start();
        }

        if (anchor == null)
            return;

        float step = rotationSpeed * Time.deltaTime;
        anchor.transform.Rotate(0, 0, -step);
        rotated += step;

        if (rotated >= 135f)
        {
            Attack_1End();
        }
    }

    void Attack_1End()
    {
        Destroy(anchor);
        Destroy(sword);
    }
}
