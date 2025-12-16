using System.Linq;

[System.Serializable]
public class MapRegistry
{
    public DriftwoodRiverSO driftwoodRiverSO;
    public ShadowmoonMarshSO shadowmoonMarshSO;
    public ArcaneLakeSO arcaneLakeSO;

    // List of maps
    public MapSO[] AllMaps =>
        new MapSO[]
        {
            driftwoodRiverSO,
            shadowmoonMarshSO,
            arcaneLakeSO
        };

    public void Initialize()
    {
        driftwoodRiverSO.Initialize();
        shadowmoonMarshSO.Initialize();
        arcaneLakeSO.Initialize();
    }

    public MapSO GetByName(string mapName)
    {
        return AllMaps.FirstOrDefault(m => m.mapName == mapName);
    }
}
