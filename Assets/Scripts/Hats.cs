using UnityEngine;

public class Hats : MonoBehaviour
{
    public Sprite[] FrontSprites;
    public Sprite[] SideSprites;
    public Sprite[] BackSprites;
    public PlayerMovement movement;
    public PlayerStats playerStats;
    SpriteRenderer hatRenderer;

    void Start()
    {
        hatRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        hatController(playerStats.hat, movement.faceingState);
    }

    void hatController(int hatNumber, int isFacing) // 0 Up; 1 Down; 2 Right; 3 Left;
    {
        // 0 = no hat
        if (hatNumber == 0)
        {
            hatRenderer.sprite = null;
            hatRenderer.enabled = false;
            return;
        }

        hatRenderer.enabled = true;
        int index = hatNumber - 1;

        switch (isFacing)
        {
            case 0: // Back
                if (index < BackSprites.Length)
                    hatRenderer.sprite = BackSprites[index];
                break;

            case 1: // Front
                if (index < FrontSprites.Length)
                    hatRenderer.sprite = FrontSprites[index];
                break;

            case 2: // Right
                if (index < SideSprites.Length)
                    hatRenderer.sprite = SideSprites[index];
                break;

            case 3: // Left
                if (index < SideSprites.Length)
                    hatRenderer.sprite = SideSprites[index];
                break;
        }
    }
}