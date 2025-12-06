using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient/MysticEssence")]
public class MysticEssenceSO : IngredientSO
{
    public override void Initialize()
    {
        this.ingredientName = "Mystic Essence";
        this.playerQuantityPossessed = 0;
    }
}