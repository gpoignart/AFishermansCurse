using UnityEngine;

[CreateAssetMenu(menuName = "FishType/MysticFish")]
public class MysticFish : FishType
{
    private void OnEnable()
    {
        this.fishName = "MysticFish";
        this.color = Color.black;
        this.spawnMaps = new Map[] { Map.MapThree };
        this.spawnTimes = new TimeOfDay[] { TimeOfDay.Night };
        this.drops = new Ingredient[] { Ingredient.MysticEssence };
        this.spawnChance = 5;
        this.catchingDifficulties = new FishCatchingDifficulty[]
        {
            new FishCatchingDifficulty(time: TimeOfDay.Night, safeZoneMoveSpeed: 200f, requiredTimeInsideZone: 3f, allowedTimeOutsideZone: 2f, safeZoneWidth: 80f)
        };
    }
}