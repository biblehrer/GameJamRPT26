using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("Scripts")]
    PlayerStats stats;
    PlayerMovement move;

    [Header("Level")]
    public int PlayerLevel = 1;
    public float PlayerXP = 0f;

    public float BaseXP = 100f;
    public float Exponent = 2f;
    public int MaxLevel = 100;

    public float XPToNextLevel(int level)
    {
        return Mathf.Round(BaseXP * Mathf.Pow(level, Exponent));
    }

    public void AddXP(float amount)
    {
        if (PlayerLevel >= MaxLevel) return;

        PlayerXP += amount;

        while (PlayerXP >= XPToNextLevel(PlayerLevel) && PlayerLevel < MaxLevel)
        {
            PlayerXP -= XPToNextLevel(PlayerLevel);
            PlayerLevel++;
            OnLevelUp(PlayerLevel);
        }

        if (PlayerLevel >= MaxLevel)
            PlayerXP = 0f;
    }

    private void OnLevelUp(int newLevel)
    {
        Debug.Log($"Level up! Now level {newLevel}");
    }

    public float XPProgress()
    {
        if (PlayerLevel >= MaxLevel) return 1f;
        return PlayerXP / XPToNextLevel(PlayerLevel);
    }

    public void Stats()
    {
        float multiplier = Mathf.Pow(1.01f, PlayerLevel - 1);
        stats.maxHealth   = Mathf.RoundToInt(stats.maxHealth * multiplier);
        move.speed = move.speed * multiplier;
    }
}