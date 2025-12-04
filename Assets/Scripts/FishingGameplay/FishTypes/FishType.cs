using UnityEngine;

public abstract class FishType : ScriptableObject
{
    public string fishName;
  //  public Sprite sprite;  To put when we'll got real sprite
    public Color color; // To remove when we'll got real sprite
    public Map[] spawnMaps;
    public TimeOfDay[] spawnTimes;
    public Ingredient[] drops;
    public int spawnChance;
    public FishCatchingDifficulty[] catchingDifficulties;
}

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