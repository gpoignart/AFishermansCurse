using UnityEngine;

[CreateAssetMenu(menuName = "FishType/MidnightCatfish")]
public class MidnightCatfish : FishType
{
    private void OnEnable()
    {
        this.fishName = "MidnightCatfish";
        this.color = Color.magenta;
        this.spawnMaps = new Map[] { Map.MapTwo };
        this.spawnTimes = new TimeOfDay[] { TimeOfDay.Night };
        this.drops = new Ingredient[] { Ingredient.ShadowyEye };
        this.spawnChance = 15;
        this.catchingDifficulties = new FishCatchingDifficulty[]
        {
            new FishCatchingDifficulty(time: TimeOfDay.Night, safeZoneMoveSpeed: 170f, requiredTimeInsideZone: 3f,allowedTimeOutsideZone: 2.5f, safeZoneWidth: 100f)
        };
    }
}