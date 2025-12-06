using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient/CarpTooth")]
public class CarpToothSO : IngredientSO
{
    public override void Initialize()
    {
        this.ingredientName = "Carp Tooth";
        this.playerQuantityPossessed = 0;
    }
}