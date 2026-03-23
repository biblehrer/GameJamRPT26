using UnityEngine;

public class HPBardLogic : MonoBehaviour
{
    public playerhealth PlayerHp;

    public GameObject HPBarMax;
    public GameObject HpBar;
    public GameObject HPBarEnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar();
    }

        void HPBar()
    {
        float MaxHpScale;
        float HpScale;

        MaxHpScale =PlayerHp.maxHealth / 10f;
        HpScale =PlayerHp.health / 10f;

        HPBarMax.transform.localScale = new Vector3(MaxHpScale,1,1);
        HpBar.transform.localScale = new Vector3(HpScale,1,1);
        HPBarEnd.transform.localPosition = new Vector3(PlayerHp.maxHealth- 5.5f,0,0); 
    }
}
