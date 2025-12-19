using UnityEngine;

[CreateAssetMenu(menuName = "PlayerEquipment/FishingRod")]
public class FishingRodSO : PlayerEquipmentSO
{
    public override void Initialize()
    {
        this.playerEquipmentName = "Fishing Rod";
        this.level = 1;
        this.detailsPerLevel = new string[]
        {
            "No bonus",
            "Decreases needed time in green zones",
            "Increases green zones width"
        };
    }

    public override void UpgradeTo(int newLevel)
    {
        this.level = newLevel;
        if (this.level == 2)
        {
            // Decreases the requiredTimeInsideZone of 30% for all fish
            foreach (FishSO fish in GameManager.Instance.FishRegistry.AllFish)
            {
                foreach (FishCatchingDifficulty catchingDifficulty in fish.catchingDifficulties)
                {
                    catchingDifficulty.requiredTimeInsideZone *= 0.7f;
                }
            }
        }
        else if (this.level == 3)
        {
            // Increases the safeZoneWidth for all fish, inversely proportional
            foreach (FishSO fish in GameManager.Instance.FishRegistry.AllFish)
            {
                foreach (FishCatchingDifficulty catchingDifficulty in fish.catchingDifficulties)
                {
                    catchingDifficulty.safeZoneWidth += 2400f / catchingDifficulty.safeZoneWidth;
                }
            }
        }
    }
}

