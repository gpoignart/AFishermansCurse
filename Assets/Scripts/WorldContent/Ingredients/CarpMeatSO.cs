using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient/CarpMeat")]
public class CarpMeatSO : IngredientSO
{
    public override void Initialize()
    {
        this.ingredientName = "Carp Meat";
        this.playerQuantityPossessed = 0;
    }
}