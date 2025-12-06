using UnityEngine;

[CreateAssetMenu(menuName = "Recipe/FishermansMix")]
public class FishermansMixSO : RecipeSO
{
    public override void Initialize()
    {
        recipeName = "Fisherman’s Mix";
        description = "Upgrades Boat to level 2.";
        ingredients = new RecipeIngredient[]
        {
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.carpMeatSO, quantity: 5),
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.carpToothSO, quantity: 5),
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.troutMeatSO, quantity: 5),
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.shinyFinSO, quantity: 5),
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.glimmeringScaleSO, quantity: 1)
        };
        hasAlreadyBeenUsed = false;
        isFinalRecipe = false;
        upgradesEquipment = GameManager.Instance.PlayerEquipmentRegistry.boatSO;
        upgradesToLevel = 2;
    }
}
