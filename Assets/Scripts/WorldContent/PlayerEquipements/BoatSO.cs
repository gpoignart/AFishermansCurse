using UnityEngine;

[CreateAssetMenu(menuName = "PlayerEquipment/Boat")]
public class BoatSO : PlayerEquipmentSO
{
    public override void Initialize()
    {
        this.equipmentName = "Boat";
        this.level = 1;
    }
}