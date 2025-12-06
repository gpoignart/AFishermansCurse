[System.Serializable]
public class PlayerEquipmentRegistry
{
    public BoatSO boatSO;
    public FishingRodSO fishingRodSO;
    public FlashlightSO flashlightSO;

    public void Initialize()
    {
        boatSO.Initialize();
        fishingRodSO.Initialize();  
        flashlightSO.Initialize();
    }
}
