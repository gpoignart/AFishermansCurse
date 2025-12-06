using UnityEngine;

[CreateAssetMenu(menuName = "Recipe/ElixirOfTheCursed")]
public class ElixirOfTheCursedSO : RecipeSO
{
    public override void Initialize()
    {
        recipeName = "Elixir of the Cursed";
        description = "Heals any curse.";
        ingredients = new RecipeIngredient[]
        {
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.glimmeringScaleSO, quantity: 10),
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.shadowingEyeSO, quantity: 5),
            new RecipeIngredient(ingredientSO: GameManager.Instance.IngredientRegistry.mysticEssenceSO, quantity: 3)
        };
        hasAlreadyBeenUsed = false;
        isFinalRecipe = true;
    }
}
