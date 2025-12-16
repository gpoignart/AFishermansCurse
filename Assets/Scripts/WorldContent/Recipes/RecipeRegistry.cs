using System.Linq;

[System.Serializable]
public class RecipeRegistry
{
    public CarpSkilletSO carpSkilletSO;
    public TroutSkilletSO troutSkilletSO;
    public FishermansMixSO fishermansMixSO;
    public GoldenCarpFilletSO goldenCarpFilletSO;
    public GoldenTroutFilletSO goldenTroutFilletSO;
    public CatfishNightStewSO catfishNightStewSO;
    public ElixirOfTheCursedSO elixirOfTheCursedSO;

    // List of recipes
    public RecipeSO[] AllRecipes =>
        new RecipeSO[]
        {
            carpSkilletSO,
            troutSkilletSO,
            fishermansMixSO,
            goldenCarpFilletSO,
            goldenTroutFilletSO,
            catfishNightStewSO,
            elixirOfTheCursedSO
        };

    public void Initialize()
    {
        carpSkilletSO.Initialize();
        troutSkilletSO.Initialize();
        fishermansMixSO.Initialize();
        goldenCarpFilletSO.Initialize();
        goldenTroutFilletSO.Initialize();
        catfishNightStewSO.Initialize();
        elixirOfTheCursedSO.Initialize();
    }

    public RecipeSO GetByName(string recipeName)
    {
        return AllRecipes.FirstOrDefault(r => r.recipeName == recipeName);
    }
}
