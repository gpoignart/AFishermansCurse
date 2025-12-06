using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient/GlimmeringScale")]
public class GlimmeringScaleSO : IngredientSO
{
    public override void Initialize()
    {
        this.ingredientName = "Glimmering Scale";
        this.playerQuantityPossessed = 0;
    }
}