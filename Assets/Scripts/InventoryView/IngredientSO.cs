using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient")]
public class IngredientSO : ScriptableObject
{
    public Ingredient ingredient;
    public Sprite sprite;
    public Color color;
}