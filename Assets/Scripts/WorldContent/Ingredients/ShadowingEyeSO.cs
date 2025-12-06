using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient/ShadowingEye")]
public class ShadowingEyeSO : IngredientSO
{
    public override void Initialize()
    {
        this.ingredientName = "Shadowing Eye";
        this.playerQuantityPossessed = 0;
    }
}