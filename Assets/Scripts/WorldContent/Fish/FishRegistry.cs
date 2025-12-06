[System.Serializable]
public class FishRegistry
{
    public CarpSO carpSO;
    public TroutSO troutSO;
    public GoldenSalmonSO goldenSalmonSO;
    public MidnightCatfishSO midnightCatfishSO;
    public MysticFishSO mysticFishSO;

    // List of fish
    public FishSO[] AllFish =>
        new FishSO[]
        {
            carpSO,
            troutSO,
            goldenSalmonSO,
            midnightCatfishSO,
            mysticFishSO
        };

    public void Initialize()
    {
        carpSO.Initialize();
        troutSO.Initialize();
        goldenSalmonSO.Initialize();
        midnightCatfishSO.Initialize();
        mysticFishSO.Initialize();
    }
}

