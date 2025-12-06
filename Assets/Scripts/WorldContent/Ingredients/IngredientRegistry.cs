[System.Serializable]
public class IngredientRegistry
{
    public CarpMeatSO carpMeatSO;
    public CarpToothSO carpToothSO;
    public TroutMeatSO troutMeatSO;
    public ShinyFinSO shinyFinSO;
    public GlimmeringScaleSO glimmeringScaleSO;
    public ShadowingEyeSO shadowingEyeSO;
    public MysticEssenceSO mysticEssenceSO;

    // List of ingredients to display them more easily in inventory
    public IngredientSO[] AllIngredients =>
        new IngredientSO[]
        {
            carpMeatSO,
            carpToothSO,
            troutMeatSO,
            shinyFinSO,
            glimmeringScaleSO,
            shadowingEyeSO,
            mysticEssenceSO
        };

    public void Initialize()
    {
        carpMeatSO.Initialize();
        carpToothSO.Initialize();
        troutMeatSO.Initialize();
        shinyFinSO.Initialize();
        glimmeringScaleSO.Initialize();
        shadowingEyeSO.Initialize();
        mysticEssenceSO.Initialize();
    }
}

