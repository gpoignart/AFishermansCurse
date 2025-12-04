using UnityEngine;

[CreateAssetMenu(menuName = "FishType/GoldenSalmon")]
public class GoldenSalmon : FishType
{
    private void OnEnable()
    {
        this.fishName = "GoldenSalmon";
        this.color = Color.yellow;
        this.spawnMaps = new Map[] { Map.MapOne };
        this.spawnTimes = new TimeOfDay[] { TimeOfDay.Day, TimeOfDay.Night };
        this.drops = new Ingredient[] { Ingredient.GlimmeringScale };
        this.spawnChance = 30;
        this.catchingDifficulties = new FishCatchingDifficulty[]
        {
            new FishCatchingDifficulty(time: TimeOfDay.Day, safeZoneMoveSpeed: 130f, requiredTimeInsideZone: 2.5f,allowedTimeOutsideZone: 2.5f, safeZoneWidth: 130f),
            new FishCatchingDifficulty(time: TimeOfDay.Night, safeZoneMoveSpeed: 150f, requiredTimeInsideZone: 3f,allowedTimeOutsideZone: 2f, safeZoneWidth: 130f)
        };
    }
}