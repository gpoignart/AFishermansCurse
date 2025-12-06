using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient/TroutMeat")]
public class TroutMeatSO : IngredientSO
{
    public override void Initialize()
    {
        this.ingredientName = "Trout Meat";
        this.playerQuantityPossessed = 0;
    }
}