using System.Linq;

[System.Serializable]
public class PlayerEquipmentRegistry
{
    public BoatSO boatSO;
    public FishingRodSO fishingRodSO;
    public FlashlightSO flashlightSO;

    // List of player equipment
    public PlayerEquipmentSO[] AllPlayerEquipments =>
        new PlayerEquipmentSO[]
        {
            fishingRodSO,
            boatSO,
            flashlightSO
        };

    public void Initialize()
    {
        boatSO.Initialize();
        fishingRodSO.Initialize();  
        flashlightSO.Initialize();
    }

    public PlayerEquipmentSO GetByName(string playerEquipmentName)
    {
        return AllPlayerEquipments.FirstOrDefault(e => e.playerEquipmentName == playerEquipmentName);
    }
}
