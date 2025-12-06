using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient/ShinyFin")]
public class ShinyFinSO : IngredientSO
{
    public override void Initialize()
    {
        this.ingredientName = "Shiny Fin";
        this.playerQuantityPossessed = 0;
    }
}