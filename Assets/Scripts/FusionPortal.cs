using UnityEngine;

public class FusionPortal : MonoBehaviour
{
    public GameObject Info;
    public int deathtimer = 10;
    bool playerInRange;
    PlayerHealth playerHealth;
    void Start()
    {
        Destroy(gameObject,deathtimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("ActionButten") && playerInRange)
        {
            CombineSwords();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerInRange = true;
            Info.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            Info.SetActive(false);
        }
    }

    void CombineSwords()
    {
        // 2 Wood → 1 Bone
        int woodPairs = playerHealth.swordCollection[SwordType.WoodSword] / 2;
        playerHealth.swordCollection[SwordType.WoodSword]  -= woodPairs * 2;
        playerHealth.swordCollection[SwordType.BoneSword]  += woodPairs;

        // 2 Bone → 1 Iron
        int bonePairs = playerHealth.swordCollection[SwordType.BoneSword] / 2;
        playerHealth.swordCollection[SwordType.BoneSword]  -= bonePairs * 2;
        playerHealth.swordCollection[SwordType.IronSword]  += bonePairs;

        // 2 Iron → 1 Fire
        int ironPairs = playerHealth.swordCollection[SwordType.IronSword] / 2;
        playerHealth.swordCollection[SwordType.IronSword]  -= ironPairs * 2;
        playerHealth.swordCollection[SwordType.FireSword]  += ironPairs;

        // 2 Fire → 1 Diamond
        int firePairs = playerHealth.swordCollection[SwordType.FireSword] / 2;
        playerHealth.swordCollection[SwordType.FireSword]    -= firePairs * 2;
        playerHealth.swordCollection[SwordType.DiamondSword] += firePairs;

        // 1 Diamond + 1 Netherrite → 1 Destroyer
        int destroyerCrafts = Mathf.Min(
            playerHealth.swordCollection[SwordType.DiamondSword],
            playerHealth.swordCollection[SwordType.Netherrite]
        );
        playerHealth.swordCollection[SwordType.DiamondSword]  -= destroyerCrafts;
        playerHealth.swordCollection[SwordType.Netherrite]    -= destroyerCrafts;
        playerHealth.swordCollection[SwordType.DestroyerSword]+= destroyerCrafts;
    }
}
