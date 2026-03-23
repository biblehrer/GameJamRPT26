using JetBrains.Annotations;
using UnityEngine;

public class Attack_1 : MonoBehaviour
{   
    public GameObject anchorPrefab;
    public GameObject swordPrefab;
    GameObject anchor;
    GameObject sword;

    void Start()
    {
        anchor = Instantiate(anchorPrefab, transform);
        sword = Instantiate(swordPrefab, new Vector3(0, 1, 0), Quaternion.identity, anchor.transform);
    }

    void Update()
    {   
        float z = anchor.transform.rotation.z + 1 * Time.deltaTime;
        anchor.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
    }
}
