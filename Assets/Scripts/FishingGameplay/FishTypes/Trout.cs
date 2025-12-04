using UnityEngine;

[CreateAssetMenu(menuName = "FishType/Trout")]
public class Trout : FishType
{
    private void OnEnable()
    {
        this.fishName = "Trout";
        this.color = Color.red;
        this.spawnMaps = new Map[] { Map.MapOne, Map.MapThree };
        this.spawnTimes = new TimeOfDay[] { TimeOfDay.Day, TimeOfDay.Night };
        this.drops = new Ingredient[] { Ingredient.TroutMeat, Ingredient.ShinyFin };
        this.spawnChance = 70;
        this.catchingDifficulties = new FishCatchingDifficulty[]
        {
            new FishCatchingDifficulty(time: TimeOfDay.Day, safeZoneMoveSpeed: 100f, requiredTimeInsideZone: 1.5f,allowedTimeOutsideZone: 3.5f, safeZoneWidth: 170f),
            new FishCatchingDifficulty(time: TimeOfDay.Night, safeZoneMoveSpeed: 120f, requiredTimeInsideZone: 2f,allowedTimeOutsideZone: 3f, safeZoneWidth: 170f)
        };
    }
}