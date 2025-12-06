using UnityEngine;

[CreateAssetMenu(menuName = "PlayerEquipment/Flashlight")]
public class FlashlightSO : PlayerEquipmentSO
{
    public override void Initialize()
    {
        this.equipmentName = "Flashlight";
        this.level = 1;
    }
}