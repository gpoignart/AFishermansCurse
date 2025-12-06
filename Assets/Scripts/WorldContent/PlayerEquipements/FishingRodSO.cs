using UnityEngine;

[CreateAssetMenu(menuName = "PlayerEquipment/FishingRod")]
public class FishingRodSO : PlayerEquipmentSO
{
    public override void Initialize()
    {
        this.equipmentName = "Fishing Rod";
        this.level = 1;
    }
}