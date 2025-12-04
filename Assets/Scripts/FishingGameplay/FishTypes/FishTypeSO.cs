using UnityEngine;

public abstract class FishTypeSO : ScriptableObject
{
    public string fishName;
    public Sprite sprite;
    public Color color; // To remove when we'll got real sprite
    public Map[] spawnMaps;
    public TimeOfDay[] spawnTimes;
    public Ingredient[] drops;
    public int spawnChance;
    public FishCatchingDifficulty[] catchingDifficulties;
}

[System.Serializable] // Needed for an intern class
public class FishCatchingDifficulty
{
    public TimeOfDay time; // Day or night

    public float safeZoneMoveSpeed = 100f;
    public float requiredTimeInsideZone = 2f;
    public float allowedTimeOutsideZone = 3f;
    public float safeZoneWidth = 150f;

    // Default constructor
    public FishCatchingDifficulty(TimeOfDay time)
    {
        this.time = time;
    }

    // Constructor with difficulty parameters
    public FishCatchingDifficulty(TimeOfDay time, float safeZoneMoveSpeed, float requiredTimeInsideZone, float allowedTimeOutsideZone, float safeZoneWidth)
    {
        this.time = time;
        this.safeZoneMoveSpeed = safeZoneMoveSpeed;
        this.requiredTimeInsideZone = requiredTimeInsideZone;
        this.allowedTimeOutsideZone = allowedTimeOutsideZone;
        this.safeZoneWidth = safeZoneWidth;
    }
}