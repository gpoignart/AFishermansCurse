using UnityEngine;

[CreateAssetMenu(menuName = "FishType/Carp")]
public class CarpSO : FishTypeSO
{
    private void OnEnable()
    {
        this.fishName = "Carp";
        this.color = Color.gray;
        this.spawnMaps = new Map[] { Map.MapOne, Map.MapTwo };
        this.spawnTimes = new TimeOfDay[] { TimeOfDay.Day, TimeOfDay.Night };
        this.drops = new Ingredient[] { Ingredient.CarpMeat, Ingredient.CarpTooth };
        this.spawnChance = 80;
        this.catchingDifficulties = new FishCatchingDifficulty[]
        {
            new FishCatchingDifficulty(time: TimeOfDay.Day, safeZoneMoveSpeed: 80f, requiredTimeInsideZone: 2f,allowedTimeOutsideZone: 3f, safeZoneWidth: 200f),
            new FishCatchingDifficulty(time: TimeOfDay.Night, safeZoneMoveSpeed: 100f, requiredTimeInsideZone: 2.5f,allowedTimeOutsideZone: 2.5f, safeZoneWidth: 200f)
        };
    }
}